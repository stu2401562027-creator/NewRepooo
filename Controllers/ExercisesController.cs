using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ExercisesController : ControllerBase
{
    private readonly AppDbContext _db;
    public ExercisesController(AppDbContext db) { _db = db; }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _db.Exercises.Include(e=>e.ExerciseCategory).ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Exercise ex) { _db.Exercises.Add(ex); await _db.SaveChangesAsync(); return CreatedAtAction(nameof(Get), new { id = ex.Id }, ex); }
}
