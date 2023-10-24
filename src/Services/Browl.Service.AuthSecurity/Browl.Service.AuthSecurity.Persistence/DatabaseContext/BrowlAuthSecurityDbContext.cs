using System.Data;

using Browl.Service.AuthSecurity.Application.Contracts.Identity;
using Browl.Service.AuthSecurity.Domain.Common;

using Microsoft.EntityFrameworkCore;

namespace Browl.Service.AuthSecurity.Persistence.DatabaseContext;

public class HrDatabaseContext : DbContext
{
	private readonly IUserService _userService;

	public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options, IUserService userService) : base(options) => _userService = userService;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		_ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
			.Where(q => q.State is EntityState.Added or EntityState.Modified))
		{
			entry.Entity.DateModified = DateTime.Now;
			entry.Entity.ModifiedBy = _userService.UserId;
			if (entry.State == EntityState.Added)
			{
				entry.Entity.DateCreated = DateTime.Now;
				entry.Entity.CreatedBy = _userService.UserId;
			}
		}

		return base.SaveChangesAsync(cancellationToken);
	}

}
