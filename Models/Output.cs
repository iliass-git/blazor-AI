namespace BlazorAI.Models;

public class Output
{
    public string Id { get; set; }
    public Status Status { get; set; }
    public string Created_at { get; set; }
    public Model Model { get; set; }
    public Input Input { get; set; }
    public Data Data { get; set; }
}
