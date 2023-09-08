using Browl.Service.MarketDataCollector.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		_ = builder.ToTable("Products");
		_ = builder.HasKey(p => p.Id);
		_ = builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
		_ = builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
		_ = builder.Property(p => p.QuantityInPackage).IsRequired();
		_ = builder.Property(p => p.UnitOfMeasurement).IsRequired();
	}
}