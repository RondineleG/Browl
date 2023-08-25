namespace Browl.Data.Interfaces;
public interface ITenantService
{
    public string GetConnectionString();
    public Tenant GetTenant();
}