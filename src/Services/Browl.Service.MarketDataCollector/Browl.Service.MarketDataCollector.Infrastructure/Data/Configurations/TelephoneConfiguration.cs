using Browl.Service.MarketDataCollector.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Configurations;

public class TelephoneConfiguration : IEntityTypeConfiguration<Telephone>
{
<<<<<<< HEAD
	public void Configure(EntityTypeBuilder<Telephone> builder) => _ = builder.HasKey(p => new { p.ClienteId, p.Numero });
=======
    public void Configure(EntityTypeBuilder<Telephone> builder)
    {
        builder.HasKey(p => new { p.ClienteId, p.Numero });
    }
>>>>>>> dev
}