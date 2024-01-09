namespace Foo.Models;

public class UserClaimsTable
{
    public int Id { get; set; }
    public string? UserClaimsClaimId { get; set; }
    public ClaimTable? ClaimTable { get; set; }
    public string? UserTableUserId { get; set; }
    public UserTable? UserTable {get;set;}
}