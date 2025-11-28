namespace Backend.Models;
public class Workout
{
    public int Id { get; set; }
    public DateTime PerformedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public User? User { get; set; }

    // One-to-many: Workout -> WorkoutExercises
    public List<WorkoutExercise>? WorkoutExercises { get; set; }
}
