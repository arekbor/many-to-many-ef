namespace Foo.Models;

public class ClaimTable 
{
    public int Id { get; set; }
    public string? ClaimName { get; set; }
    public string? ClaimId { get; set; }
    public ICollection<UserTable> UserTables = [];
}