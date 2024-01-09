using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foo.Configurations;

public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
    where T : class
{
    protected abstract string Table { get; }
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(Table);
    }
}