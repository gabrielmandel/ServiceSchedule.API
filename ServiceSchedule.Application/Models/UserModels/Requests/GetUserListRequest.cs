using ServiceSchedule.Domain.User;

namespace ServiceSchedule.Application.Models.UserModels.Requests
{
    public class GetUserListRequest
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsActive { get; set; } = false;
    }
}
