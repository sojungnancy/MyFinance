namespace backend.Models;

public class Announcement
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation
    public User? Creator { get; set; }
}
