namespace Foo.Entities;

public class ClaimTable 
{
    public int Id { get; set; }
    public string? ClaimName { get; set; }
    public string? ClaimId { get; set; }
    //enter collecion
    public ICollection<UserTable> UserTables = [];
}