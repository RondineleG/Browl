using Browl.Service.MarketDataCollector.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
<<<<<<< HEAD
	public void Configure(EntityTypeBuilder<User> builder) => _ = builder.HasKey(k => k.Login);
=======
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(k => k.Login);
    }
>>>>>>> dev
}