namespace MockupResponseCMS.API.Models
{
    public class BaseCommandResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public List<Parameter> Parameters { get; set; }
    }
}
