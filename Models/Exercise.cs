namespace Backend.Models;
public class Exercise
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public int ExerciseCategoryId { get; set; }
    public ExerciseCategory? ExerciseCategory { get; set; }

    // Many-to-many: Exercise <-> WorkoutPlan via PlanExercise
    public List<PlanExercise>? PlanExercises { get; set; }

    // Many-to-many instance: Exercise <-> Workout via WorkoutExercise
    public List<WorkoutExercise>? WorkoutExercises { get; set; }
}
