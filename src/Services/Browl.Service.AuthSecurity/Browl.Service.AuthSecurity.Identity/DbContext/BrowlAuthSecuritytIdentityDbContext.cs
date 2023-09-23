using Browl.Service.AuthSecurity.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.AuthSecurity.Identity.DbContext
{
    public class BrowlAuthSecuritytIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public BrowlAuthSecuritytIdentityDbContext(DbContextOptions<BrowlAuthSecuritytIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(BrowlAuthSecuritytIdentityDbContext).Assembly);
        }
    }
}
