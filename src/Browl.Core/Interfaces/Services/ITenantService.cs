using Browl.Core.Entities;

namespace Browl.Core.Interfaces.Services;
public interface ITenantService
{
    public string GetConnectionString();
    public Tenant GetTenant();
}