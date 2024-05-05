
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickOut.Domain.Estabilishments
{
    public class EstabilishmentTypeConfiguration : IEntityTypeConfiguration<Estabilishment>
    {
        public void Configure(EntityTypeBuilder<Estabilishment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(120);

            builder.HasMany(x => x.Sections);

            builder.OwnsOne(x => x.CNPJ);
            builder.OwnsOne(x => x.Email);
            builder.OwnsOne(x => x.Address);

        }
    }
}
