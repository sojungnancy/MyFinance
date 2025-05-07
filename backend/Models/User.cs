namespace backend.Models
{
    public class User
    {
        public int id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public string ProviderId { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
    }

    
}
