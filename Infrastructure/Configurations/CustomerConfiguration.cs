using Microsoft.EntityFrameworkCore;
using Domain.Customers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Id).HasConversion(
            customerId => customerId.Value,
            value => new CustomerId(value));

        builder.Property(customer => customer.Name).HasMaxLength(100);

        builder.Property(customer => customer.Email).HasMaxLength(255);

        builder.HasIndex(customer => customer.Email).IsUnique();
    }
}
