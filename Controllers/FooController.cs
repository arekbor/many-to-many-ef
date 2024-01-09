using Foo.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Foo.Controllers;


[ApiController]
public class FooController : ControllerBase
{
    private readonly AppDbContext _db;
    public FooController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet("fooTest")]
    public async Task<IActionResult> FooTest(string userId) 
    {
        var claims = await _db.Set<UserTable>()
            .Include(x => x.ClaimTables)
            .FirstOrDefaultAsync(x => x.UserId == userId);


        return Ok(claims?.ClaimTables);
    }
}