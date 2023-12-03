namespace BlazorAI.Models;

public class ModelVersion
{
    public string Id { get; set; }
    public DateTime Created_at { get; set; }
    public Status Status { get; set; }
    public Visibility Visibility { get; set; }
    public string App_id { get; set; }
    public string User_id { get; set; }
    public Metadata Metadata { get; set; }
}
