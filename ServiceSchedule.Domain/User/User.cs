namespace ServiceSchedule.Domain.User
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public List<Role> Roles { get; set; }
        // Additional properties can be added based on your specific requirements

        // Constructor
        public User()
        {
            Roles = new List<Role>();
        }
    }
}
