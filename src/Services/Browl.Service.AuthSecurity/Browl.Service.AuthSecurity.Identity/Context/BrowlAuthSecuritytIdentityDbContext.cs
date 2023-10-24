using Browl.Service.AuthSecurity.Identity.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.AuthSecurity.Identity.Context;

public class BrowlAuthSecuritytIdentityDbContext : IdentityDbContext<ApplicationUser>
{
	public BrowlAuthSecuritytIdentityDbContext(DbContextOptions<BrowlAuthSecuritytIdentityDbContext> options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		_ = builder.ApplyConfigurationsFromAssembly(typeof(BrowlAuthSecuritytIdentityDbContext).Assembly);
	}
}
