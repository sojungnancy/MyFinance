namespace backend.Models;

public class Feedback
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }
    public string? Status { get; set; } // 'pending' / 'reviewed' / 'responded'
    public string? AdminReply { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation
    public User? User { get; set; }
}
