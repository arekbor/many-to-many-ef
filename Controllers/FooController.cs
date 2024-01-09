using Foo.Models;
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
    public async Task<IActionResult> FooTest(string claimId) 
    {
        var claims = await _db.Set<ClaimTable>()
            .AsQueryable()
            .Include(x => x.UserTables)
            .ToListAsync();


        return Ok(claims);
    }
}