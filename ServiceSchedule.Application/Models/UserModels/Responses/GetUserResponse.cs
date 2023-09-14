using ServiceSchedule.Domain.User;

namespace ServiceSchedule.Application.Models.UserModels.Responses
{
    public class GetUserResponse
    {
        public string? Email { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public bool? IsActive { get; set; } = false;
        public string? ProfileImageUrl { get; set; } = string.Empty;
        public List<Role>? Roles { get; set; } = new List<Role>();

    }
}
