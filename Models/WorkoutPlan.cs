namespace Backend.Models;
public class WorkoutPlan
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    // Many-to-many: WorkoutPlan <-> Exercise
    public List<PlanExercise>? PlanExercises { get; set; }
}
