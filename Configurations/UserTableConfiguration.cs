using Foo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foo.Configurations;

internal sealed class UserTableConfiguration : BaseEntityTypeConfiguration<UserTable>
{
    protected override string Table => "user_table";
    public override void Configure(EntityTypeBuilder<UserTable> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Username)
            .HasColumnName("username");
        
        builder.Property(x => x.UserId)
            .HasColumnName("user_id");

        builder
            .HasMany(e => e.ClaimTables)
            .WithMany(e => e.UserTables)
            .UsingEntity(
                //enter name of join table
                "user_claims_table",
                //enter names of reference columns
                l => l.HasOne(typeof(ClaimTable)).WithMany().HasForeignKey("user_claims_claim_id").HasPrincipalKey(nameof(ClaimTable.ClaimId)),
                r => r.HasOne(typeof(UserTable)).WithMany().HasForeignKey("user_table_user_id").HasPrincipalKey(nameof(UserTable.UserId)),
                //enter references key names
                j => j.HasKey("user_claims_claim_id", "user_table_user_id"));

        base.Configure(builder);
    }
}