using ServiceSchedule.Application.Responses;

namespace ServiceSchedule.Application.Models.UserModels.Responses
{
    public class LoginResponse : BaseResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}
