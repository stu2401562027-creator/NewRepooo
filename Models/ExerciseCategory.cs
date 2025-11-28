namespace Backend.Models;
public class ExerciseCategory
{
    public int Id { get; set; }
    public string? Name { get; set; }

    // One-to-many: Category -> Exercises
    public List<Exercise>? Exercises { get; set; }
}
