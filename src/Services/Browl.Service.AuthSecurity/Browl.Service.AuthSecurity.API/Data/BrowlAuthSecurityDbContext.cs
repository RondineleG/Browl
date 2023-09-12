using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.AuthSecurity.API.Data;

public class BrowlAuthSecurityDbContext : IdentityDbContext
{
    public BrowlAuthSecurityDbContext(DbContextOptions<BrowlAuthSecurityDbContext> options) : base(options) { }
}
