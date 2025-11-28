namespace Backend.Models;
public class ProgressEntry
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;
    public decimal WeightKg { get; set; }
    public string? Notes { get; set; }
}
