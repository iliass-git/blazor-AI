namespace BlazorAI.Models;

public class Model
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Modified_at { get; set; }
    public string App_id { get; set; }
    public ModelVersion Model_version { get; set; }
    public string User_id { get; set; }
    public string Model_type_id { get; set; }
    public Visibility Visibility { get; set; }
    public List<object> Toolkits { get; set; }
    public List<object> Use_cases { get; set; }
    public List<object> Languages { get; set; }
    public List<object> Languages_full { get; set; }
    public List<object> Check_consents { get; set; }
    public bool Workflow_recommended { get; set; }
}
