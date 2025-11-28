using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<ExerciseCategory> ExerciseCategories => Set<ExerciseCategory>();
    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<WorkoutPlan> WorkoutPlans => Set<WorkoutPlan>();
    public DbSet<PlanExercise> PlanExercises => Set<PlanExercise>();
    public DbSet<Workout> Workouts => Set<Workout>();
    public DbSet<WorkoutExercise> WorkoutExercises => Set<WorkoutExercise>();
    public DbSet<ProgressEntry> ProgressEntries => Set<ProgressEntry>();
    public DbSet<Goal> Goals => Set<Goal>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlanExercise>()
            .HasKey(pe => new { pe.WorkoutPlanId, pe.ExerciseId });

        modelBuilder.Entity<PlanExercise>()
            .HasOne(pe => pe.WorkoutPlan)
            .WithMany(wp => wp.PlanExercises)
            .HasForeignKey(pe => pe.WorkoutPlanId);

        modelBuilder.Entity<PlanExercise>()
            .HasOne(pe => pe.Exercise)
            .WithMany(e => e.PlanExercises)
            .HasForeignKey(pe => pe.ExerciseId);

        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.Workout)
            .WithMany(w => w.WorkoutExercises)
            .HasForeignKey(we => we.WorkoutId);

        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.Exercise)
            .WithMany(e => e.WorkoutExercises)
            .HasForeignKey(we => we.ExerciseId);

        // One-to-many relationships
        modelBuilder.Entity<User>()
            .HasMany(u => u.WorkoutPlans)
            .WithOne(wp => wp.User)
            .HasForeignKey(wp => wp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Workouts)
            .WithOne(w => w.User)
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.ProgressEntries)
            .WithOne(pe => pe.User)
            .HasForeignKey(pe => pe.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ExerciseCategory>()
            .HasMany(c => c.Exercises)
            .WithOne(e => e.ExerciseCategory)
            .HasForeignKey(e => e.ExerciseCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
