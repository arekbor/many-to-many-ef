using Foo.Entities;
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

        base.Configure(builder);
    }
}