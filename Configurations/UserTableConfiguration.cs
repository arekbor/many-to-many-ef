using Foo.Models;
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

        // builder.HasMany(x => x.ClaimTables)
        //     .WithMany(x => x.UserTables)
        //     .UsingEntity<UserClaimsTable>();

        builder.HasMany(x => x.ClaimTables)
            .WithMany(x => x.UserTables)
            .UsingEntity<UserClaimsTable>(
                j => j
                    .HasOne(x => x.ClaimTable)
                    .WithMany()
                    .HasForeignKey(x => x.UserClaimsClaimId)
                    .HasPrincipalKey(x => x.ClaimId),
                j => j
                    .HasOne(x => x.UserTable)
                    .WithMany()
                    .HasForeignKey(x => x.UserTableUserId)
                    .HasPrincipalKey(x => x.UserId),
                j =>
                {
                    j.ToTable("user_claims_table");
                    j.Property(x => x.UserTableUserId).HasColumnName("user_table_user_id");
                    j.Property(x => x.UserClaimsClaimId).HasColumnName("user_claims_claim_id");
                }
            );

        base.Configure(builder);
    }
}