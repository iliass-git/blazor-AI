using System.Text.Json;
using System.Text.Json.Serialization;
using BlazorAI.Models;

namespace BlazorAI.Services;
public class ImageprocessingService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ImageprocessingService> _logger;
    protected readonly string _clarifaiUri = "https://api.clarifai.com/v2/users/clarifai/apps/main/models/general-image-recognition/versions/aa7f35c01e0642fda5cf400f543e7c40/outputs";
    protected string _apiKey; 
    public ImageprocessingService(HttpClient httpClient, IConfiguration configuration, ILogger<ImageprocessingService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
        _apiKey = _configuration.GetValue<string>("ClarifaiApiKey");
    }
    public async Task<IList<string>> GetImageTagsAsync(string imageUrl)
    {
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Key {_apiKey}");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        var result  = new MediaModel();
        try{
            var imageBytes = await File.ReadAllBytesAsync(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", imageUrl));
            var imageBase64 = Convert.ToBase64String(imageBytes);
            
            var request = new
            {
                inputs = new[]
                {
                    new
                    {
                        data = new
                        {
                            image = new
                            {
                                base64 = imageBase64
                            }
                        }
                    }
                }
            };
            var response = await _httpClient.PostAsJsonAsync(_clarifaiUri, request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions 
            {
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                },
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            result = JsonSerializer.Deserialize<MediaModel>(responseContent,options);
        }
        catch(Exception e){
            _logger.LogError(e.Message);
        }
        var imageDescriptions = new List<string>();
        if(result == null)
        {
            _logger.LogError("API call failed");
            return imageDescriptions;
        }
        if(result == null || result.Outputs == null || result.Outputs.Count == 0)
        {
            _logger.LogError("No outputs found");
            return imageDescriptions;
        }
        foreach (var item in result.Outputs[0].Data.Concepts)
        {
            imageDescriptions.Add(item.Name);
        }
        return imageDescriptions;
    }
}
