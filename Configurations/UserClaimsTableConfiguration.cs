using Foo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foo.Configurations;

internal sealed class UserClaimsTableConfiguration : BaseEntityTypeConfiguration<UserClaimsTable>
{
    protected override string Table => "user_claims_table";
    public override void Configure(EntityTypeBuilder<UserClaimsTable> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.UserTableUserId)
            .HasColumnName("user_table_user_id");

        builder.Property(x => x.UserClaimsClaimId)
            .HasColumnName("user_claims_claim_id");

        base.Configure(builder);
    }
}