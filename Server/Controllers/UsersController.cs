using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;
using System.Threading.Tasks;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _db;
    public UsersController(AppDbContext db) => _db = db;

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return Ok(user);
    }
}