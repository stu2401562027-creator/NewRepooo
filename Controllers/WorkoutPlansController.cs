using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class WorkoutPlansController : ControllerBase
{
    private readonly AppDbContext _db;
    public WorkoutPlansController(AppDbContext db) { _db = db; }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _db.WorkoutPlans.Include(wp=>wp.PlanExercises).ThenInclude(pe=>pe.Exercise).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _db.WorkoutPlans.Include(wp=>wp.PlanExercises).ThenInclude(pe=>pe.Exercise).FirstOrDefaultAsync(wp=>wp.Id==id));

    [HttpPost]
    public async Task<IActionResult> Post(WorkoutPlan wp) { _db.WorkoutPlans.Add(wp); await _db.SaveChangesAsync(); return CreatedAtAction(nameof(Get), new { id = wp.Id }, wp); }
}
