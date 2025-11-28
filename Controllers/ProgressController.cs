using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProgressController : ControllerBase
{
    private readonly AppDbContext _db;
    public ProgressController(AppDbContext db) { _db = db; }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetForUser(int userId) => Ok(await _db.ProgressEntries.Where(p=>p.UserId==userId).ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Post(ProgressEntry entry) { _db.ProgressEntries.Add(entry); await _db.SaveChangesAsync(); return CreatedAtAction(nameof(GetForUser), new { userId = entry.UserId }, entry); }
}
