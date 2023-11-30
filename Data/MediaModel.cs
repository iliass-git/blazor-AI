    public class Concept
    {
        public string id { get; set; }
        public string name { get; set; }
        public double value { get; set; }
        public string app_id { get; set; }
    }

    public class Data
    {
        public Image image { get; set; }
        public List<Concept> concepts { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public string base64 { get; set; }
    }

    public class Input
    {
        public string id { get; set; }
        public Data data { get; set; }
    }

    public class Metadata
    {
    }

    public class Model
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime modified_at { get; set; }
        public string app_id { get; set; }
        public ModelVersion model_version { get; set; }
        public string user_id { get; set; }
        public string model_type_id { get; set; }
        public Visibility visibility { get; set; }
        public List<object> toolkits { get; set; }
        public List<object> use_cases { get; set; }
        public List<object> languages { get; set; }
        public List<object> languages_full { get; set; }
        public List<object> check_consents { get; set; }
        public bool workflow_recommended { get; set; }
    }

    public class ModelVersion
    {
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public Status status { get; set; }
        public Visibility visibility { get; set; }
        public string app_id { get; set; }
        public string user_id { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Output
    {
        public string id { get; set; }
        public Status status { get; set; }
        public string created_at { get; set; }
        public Model model { get; set; }
        public Input input { get; set; }
        public Data data { get; set; }
    }

    public class MediaModel
    {
        public Status status { get; set; }
        public List<Output> outputs { get; set; }
    }

    public class Status
    {
        public int code { get; set; }
        public string description { get; set; }
        public string req_id { get; set; }
    }

    public class Visibility
    {
        public int gettable { get; set; }
    }