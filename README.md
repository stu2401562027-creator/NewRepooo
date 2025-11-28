# Backend (ASP.NET Core Web API) - Fitness App

This backend models a simple fitness application.

Key entities (tables):
- Users
- ExerciseCategories
- Exercises
- WorkoutPlans (many-to-many with Exercises via PlanExercises)
- Workouts (user workout sessions) and WorkoutExercises (many-to-many instance)
- ProgressEntries
- Goals

Relationships:
- >=6 tables, >=4 one-to-many (User->WorkoutPlans, User->Workouts, User->ProgressEntries, ExerciseCategory->Exercises)
- >=2 many-to-many (WorkoutPlan<->Exercise via PlanExercise, Workout<->Exercise via WorkoutExercise)

How to run:
1. cd Backend
2. dotnet restore
3. dotnet run
The SQLite DB `app.db` is created automatically. Seed data is applied on first run by SeedData.EnsureSeed in Program.cs (already wired).
