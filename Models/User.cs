namespace Backend.Models;
public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    // One-to-many: User -> WorkoutPlans
    public List<WorkoutPlan>? WorkoutPlans { get; set; }

    // One-to-many: User -> Workouts (actual workout sessions)
    public List<Workout>? Workouts { get; set; }

    // One-to-many: User -> ProgressEntries
    public List<ProgressEntry>? ProgressEntries { get; set; }
}
