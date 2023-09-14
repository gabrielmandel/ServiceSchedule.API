namespace ServiceSchedule.Application.Responses
{
    public class BaseFileResponse
    {
        public byte[]? File { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
    }
}
