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
## Кратка презентация на проблема
FitnessApp е фитнес приложение, което позволява на потребителите да:
- следят тренировки и упражнения,
- управляват хранителни планове и хранителни дневници,
- проследяват прогреса си във времето.

Целта на проекта е да предостави **удобен и интерактивен инструмент** за управление на фитнес данни и планове, като същевременно улеснява треньори и фитнес специалисти.

---

## База данни
Проектът използва SQL Server с **6 таблици** и следните връзки:

- 4 връзки *едно към много* (One-to-Many)
- 2 връзки *много към много* (Many-to-Many)


---

## Таблица на API endpoints

| Endpoint | Метод | Описание | Параметри | Отговор |
|----------|-------|----------|-----------|---------|
| `/api/users` | GET | Връща списък с потребители | - | JSON масив от потребители |
| `/api/users/{id}` | GET | Връща детайли за един потребител | `id` | JSON обект на потребител |
| `/api/users` | POST | Добавя нов потребител | JSON с данни | Успешен/грешка |
| `/api/workouts` | GET | Връща всички тренировки | - | JSON масив от тренировки |
| `/api/workouts/{id}` | GET | Връща детайли за тренировка | `id` | JSON обект на тренировка |
| `/api/workouts` | POST | Добавя нова тренировка | JSON | Успешно/грешка |
| `/api/exercises` | GET | Връща упражнения | - | JSON масив |
| `/api/exercises/{id}` | GET | Детайли за упражнение | `id` | JSON обект |
| `/api/nutritionplans` | GET | Връща хранителни планове | - | JSON масив |
| `/api/progress` | GET | Връща прогрес на потребители | - | JSON масив |

> Може да добавиш допълнителни крайни точки по нужда.

---

## Скици на потребителския интерфейс
- **Главна страница (Dashboard)** – визуализация на тренировки и прогрес  
- **Страница с тренировки** – списък с всички тренировки и бутони за добавяне/редакция  
- **Страница с упражнения** – управление на упражнения по категории  
- **Хранителни планове** – списък и добавяне на нови планове  
- **Прогрес** – графики с постигнатите резултати

> Скиците са приложени в папка `UI-mockups` като PNG файлове.

Ще направим проста ERD диаграма, която включва:

Таблици: Users, Workouts, Exercises, NutritionPlans, Meals, Progress

Връзки:

One-to-Many:

User → Workouts

Workout → Exercises

User → NutritionPlans

NutritionPlan → Meals

Many-to-Many:

Users ↔ Workouts (потребител може да прави много тренировки, тренировка може да има много потребители)

Workouts ↔ Exercises (тренировка може да съдържа много упражнения, упражнение може да е в много тренировки)

<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/82f729c3-12eb-44c2-a859-335c78139542" />
