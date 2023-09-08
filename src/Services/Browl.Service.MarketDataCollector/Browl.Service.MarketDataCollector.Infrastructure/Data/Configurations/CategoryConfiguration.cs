using Browl.Service.MarketDataCollector.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			_ = builder.ToTable("Categories");
			_ = builder.HasKey(p => p.Id);
			_ = builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
			_ = builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
			_ = builder.HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
		}
	}
}