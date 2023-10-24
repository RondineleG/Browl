using Browl.Service.MarketDataCollector.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
	public void Configure(EntityTypeBuilder<Address> builder)
	{
		_ = builder.HasKey(p => p.ClienteId);
		_ = builder.Property(p => p.Estado).HasConversion(
			p => p.ToString(),
			p => (State)Enum.Parse(typeof(State), p));
	}
}
