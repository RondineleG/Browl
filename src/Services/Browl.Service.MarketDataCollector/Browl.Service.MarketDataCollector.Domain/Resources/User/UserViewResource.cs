namespace Browl.Service.MarketDataCollector.Domain.Resources.User;

public class UserViewResource
{
	public required string Login { get; set; }
	public required ICollection<RoleViewResource> Funcoes { get; set; }
}
