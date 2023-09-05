namespace Browl.Service.MarketDataCollector.Domain.Resources.User;

public class UserViewResource
{
    public string Login { get; set; }

    public ICollection<RoleViewResource> Funcoes { get; set; }
}