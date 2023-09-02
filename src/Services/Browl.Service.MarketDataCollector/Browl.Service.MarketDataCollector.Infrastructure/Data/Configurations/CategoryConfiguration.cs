using Browl.Service.MarketDataCollector.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
        }
    }
}