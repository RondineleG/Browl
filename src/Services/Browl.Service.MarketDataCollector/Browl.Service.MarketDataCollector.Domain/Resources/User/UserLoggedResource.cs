namespace Browl.Service.MarketDataCollector.Domain.Resources.User;

public class UserLoggedResource
{
	public required string Login { get; set; }
	public required ICollection<RoleViewResource> Funcoes { get; set; }
	public required string Token { get; set; }
}