using Browl.Data.Entities;
using Browl.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Browl.Data;
public class BrowlDbContext : DbContext
{
    private readonly ITenantService _tenantService;
    public BrowlDbContext(DbContextOptions options, ITenantService service) : base(options) => _tenantService = service;
    public string TenantName
    {
        get => _tenantService.GetTenant()?.TenantName ?? String.Empty;
    }
    public DbSet<Habit>? Habits { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Progress>? Progress { get; set; }
    public DbSet<Reminder>? Reminders { get; set; }
    public DbSet<Goal>? Goals { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var tenantConnectionString = _tenantService.GetConnectionString();
        if (!string.IsNullOrEmpty(tenantConnectionString))
        {
            optionsBuilder.UseSqlServer(_tenantService.GetConnectionString());
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Habit>().HasQueryFilter(a => a.TenantName == TenantName);
        SeedData.Seed(modelBuilder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ChangeTracker.Entries<IHasTenant>()
            .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified)
            .ToList().ForEach(entry => entry.Entity.TenantName = TenantName);
        return await base.SaveChangesAsync(cancellationToken);
    }
}