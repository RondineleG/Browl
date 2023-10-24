using Microsoft.EntityFrameworkCore;
using Browl.Service.DataNormalization.Domain.Entities;
using Browl.Service.DataNormalization.Domain.ValueObjects;
using Browl.Service.DataNormalization.Infrastructure.EF.Config;

namespace Browl.Service.DataNormalization.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        public DbSet<PackingList> PackingLists { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");
            
            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<PackingList>(configuration);
            modelBuilder.ApplyConfiguration<PackingItem>(configuration);
        }
    }
}