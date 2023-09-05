using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;
public class BrowlDbContext : DbContext
{
    private readonly ITenantService _tenantService;
    public BrowlDbContext(DbContextOptions options, ITenantService service) : base(options) => _tenantService = service;
    public string TenantName
    {
        get => _tenantService.GetTenant()?.TenantName ?? string.Empty;
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Habit>? Habits { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Progress>? Progress { get; set; }
    public DbSet<Reminder>? Reminders { get; set; }
    public DbSet<Goal>? Goals { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Telefone> Telefones { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Funcao> Funcoes { get; set; }

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
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
        modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //SeedData.Seed(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ChangeTracker.Entries<IHasTenant>()
            .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified)
            .ToList().ForEach(entry => entry.Entity.TenantName = TenantName);
        return await base.SaveChangesAsync(cancellationToken);
    }
}