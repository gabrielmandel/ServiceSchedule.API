namespace ServiceSchedule.Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public object? Error { get; set; } = null;
    }
}
