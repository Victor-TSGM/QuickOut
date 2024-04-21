

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOut.Domain.Common;

namespace QuickOut.Domain.Customers;

public class AddressTypeConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Country)
            .IsRequired();

        builder.Property(x => x.Street)
            .IsRequired(); 

        builder.Property(x => x.State)
            .IsRequired();

        builder.Property(x => x.AddressNumber)
            .IsRequired();

        builder.Property(x => x.PostalCode)
            .IsRequired();
    }
}
