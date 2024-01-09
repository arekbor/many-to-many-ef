namespace Foo.Entities;

public class UserTable
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? UserId { get; set; }
    //enter collecion
    public ICollection<ClaimTable> ClaimTables = [];
}