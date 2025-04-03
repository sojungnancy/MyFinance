namespace backend.Models
{
    public class Transaction
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? Memo { get; set; }

        public User? User { get; set; }
    }
}
