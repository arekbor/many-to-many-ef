using Foo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foo.Configurations;

internal sealed class ClaimTableConfiguration : BaseEntityTypeConfiguration<ClaimTable>
{
    protected override string Table => "claim_table";
    public override void Configure(EntityTypeBuilder<ClaimTable> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.ClaimId)
            .HasColumnName("claim_id");
        
        builder.Property(x => x.ClaimName)
            .HasColumnName("claim_name");

        builder.HasMany(x => x.UserTables)
            .WithMany(x => x.ClaimTables)
            .UsingEntity<UserClaimsTable>(
                j => j
                    .HasOne(x => x.UserTable)
                    .WithMany()
                    .HasForeignKey(x => x.UserTableUserId)
                    .HasPrincipalKey(x => x.UserId),
                j => j
                    .HasOne(x => x.ClaimTable)
                    .WithMany()
                    .HasForeignKey(x => x.UserClaimsClaimId)
                    .HasPrincipalKey(x => x.ClaimId),
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