using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _db;
    public UsersController(AppDbContext db) { _db = db; }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _db.Users.Include(u=>u.WorkoutPlans).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _db.Users
        .Include(u=>u.WorkoutPlans)
        .Include(u=>u.Workouts)
        .Include(u=>u.ProgressEntries)
        .FirstOrDefaultAsync(u=>u.Id==id));

    [HttpPost]
    public async Task<IActionResult> Post(User user) { _db.Users.Add(user); await _db.SaveChangesAsync(); return CreatedAtAction(nameof(Get), new { id = user.Id }, user); }
}
