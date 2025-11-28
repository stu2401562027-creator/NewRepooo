using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class WorkoutsController : ControllerBase
{
    private readonly AppDbContext _db;
    public WorkoutsController(AppDbContext db) { _db = db; }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _db.Workouts.Include(w=>w.WorkoutExercises).ThenInclude(we=>we.Exercise).ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Workout w) {
        // If workout exercises have exercise references, ensure unit IDs are present
        _db.Workouts.Add(w);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = w.Id }, w);
    }
}
