using ServiceSchedule.Domain.User;

namespace ServiceSchedule.Application.Models.UserModels.Responses
{
    public class GetUserListResponse
    {
        public List<GetUserResponse> UserList { get; set; } = new List<GetUserResponse>();

    }
}
