namespace backend.Models
{
    public class Budget
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Limit { get; set; }
        public string Month { get; set; } = string.Empty;

        public User? User { get; set; }
    }
}
