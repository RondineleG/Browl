namespace Browl.Service.MarketDataCollector.Domain.Resources.User;

public class UserLoggedResource
{
    public string Login { get; set; }
    public ICollection<RoleViewResource> Funcoes { get; set; }
    public string Token { get; set; }
}