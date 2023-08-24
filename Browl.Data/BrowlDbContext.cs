using Browl.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Browl.Data;
public class BrowlDbContext : DbContext
{
    public DbSet<Habit>? Habits { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=sqlserver;Database=GoodHabitsDatabase;User Id=sa;Password=Password1 ;Integrated Security=false;TrustServerCertificate=true;");
    protected override void OnModelCreating(ModelBuilder modelBuilder) => SeedData.Seed(modelBuilder);
}