using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickOut.Domain.Customers
{
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasMany(x => x.Sections);

            builder.OwnsOne(x => x.Name);
            builder.OwnsOne(x => x.Email);
            builder.OwnsOne(x => x.CPF);
            builder.OwnsOne(x => x.Address);
            builder.OwnsOne(x => x.Phone);
       }
    }
}
