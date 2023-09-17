using Browl.Service.AuthSecurity.API.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.AuthSecurity.API.Data;

public class BrowlAuthSecurityDbContext : IdentityDbContext<User>
{
	public BrowlAuthSecurityDbContext(DbContextOptions<BrowlAuthSecurityDbContext> options)
		: base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		var unused14 = builder.HasDefaultSchema("Identity");
		var unused13 = builder.Entity<User>(entity =>
		{
			var unused12 = entity.ToTable(name: "User");
		});

		var unused11 = builder.Entity<IdentityRole>(entity =>
		{
			var unused10 = entity.ToTable(name: "Role");
		});
		var unused9 = builder.Entity<IdentityUserRole<string>>(entity =>
		{
			var unused8 = entity.ToTable("UserRoles");
		});

		var unused7 = builder.Entity<IdentityUserClaim<string>>(entity =>
		{
			var unused6 = entity.ToTable("UserClaims");
		});

		var unused5 = builder.Entity<IdentityUserLogin<string>>(entity =>
		{
			var unused4 = entity.ToTable("UserLogins");
		});

		var unused3 = builder.Entity<IdentityRoleClaim<string>>(entity =>
		{
			var unused2 = entity.ToTable("RoleClaims");

		});

		var unused1 = builder.Entity<IdentityUserToken<string>>(entity =>
		{
			var unused = entity.ToTable("UserTokens");
		});
	}
}
