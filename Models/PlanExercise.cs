namespace Backend.Models;
public class PlanExercise
{
    public int WorkoutPlanId { get; set; }
    public WorkoutPlan? WorkoutPlan { get; set; }

    public int ExerciseId { get; set; }
    public Exercise? Exercise { get; set; }

    // Additional fields for plan (e.g., sets, reps)
    public int Sets { get; set; }
    public int Reps { get; set; }
}
