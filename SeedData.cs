using Backend.Data;
using Backend.Models;

namespace Backend;
public static class SeedData
{
    public static void EnsureSeed(AppDbContext db)
    {
        if (db.ExerciseCategories.Any()) return;

        var cat1 = new ExerciseCategory { Name = "Upper Body" };
        var cat2 = new ExerciseCategory { Name = "Lower Body" };
        db.ExerciseCategories.AddRange(cat1, cat2);

        var ex1 = new Exercise { Name = "Push-up", Description = "Bodyweight push-up", ExerciseCategory = cat1 };
        var ex2 = new Exercise { Name = "Squat", Description = "Bodyweight squat", ExerciseCategory = cat2 };
        var ex3 = new Exercise { Name = "Deadlift", Description = "Barbell deadlift", ExerciseCategory = cat2 };
        db.Exercises.AddRange(ex1, ex2, ex3);

        var user = new User { Name = "Test User", Email = "user@example.com" };
        db.Users.Add(user);

        var plan = new WorkoutPlan { Title = "Full Body Beginner", Description = "3x/week full body", User = user };
        db.WorkoutPlans.Add(plan);

        db.PlanExercises.Add(new PlanExercise { WorkoutPlan = plan, Exercise = ex1, Sets = 3, Reps = 10 });
        db.PlanExercises.Add(new PlanExercise { WorkoutPlan = plan, Exercise = ex2, Sets = 3, Reps = 12 });

        var workout = new Workout { User = user, PerformedAt = DateTime.UtcNow.AddDays(-1) };
        db.Workouts.Add(workout);
        db.WorkoutExercises.Add(new WorkoutExercise { Workout = workout, Exercise = ex1, Sets = 3, Reps = 10, Weight = 0 });
        db.WorkoutExercises.Add(new WorkoutExercise { Workout = workout, Exercise = ex2, Sets = 3, Reps = 12, Weight = 0 });

        db.ProgressEntries.Add(new ProgressEntry { User = user, Date = DateTime.UtcNow.AddDays(-7), WeightKg = 80, Notes = "Starting point" });

        db.SaveChanges();
    }
}
