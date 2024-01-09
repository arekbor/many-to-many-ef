namespace Foo.Models;

public class UserTable
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? UserId { get; set; }
    public ICollection<ClaimTable> ClaimTables = [];
}