
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

            builder.Property(x => x.CNPJ)
                .IsRequired()
                .HasMaxLength(16);

            builder.HasOne(x => x.Address);

        }
    }
}
