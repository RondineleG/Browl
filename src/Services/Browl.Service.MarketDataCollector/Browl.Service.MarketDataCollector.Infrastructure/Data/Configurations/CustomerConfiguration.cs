using Browl.Service.MarketDataCollector.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
	public void Configure(EntityTypeBuilder<Customer> builder)
	{
		_ = builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
		_ = builder.Property(p => p.Sexo).HasConversion(
			p => p.ToString(),
			p => (Gender)Enum.Parse(typeof(Gender), p));
	}
}