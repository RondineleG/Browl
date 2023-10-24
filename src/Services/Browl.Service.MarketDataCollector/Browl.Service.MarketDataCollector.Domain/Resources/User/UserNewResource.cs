namespace Browl.Service.MarketDataCollector.Domain.Resources.User;

public class UserNewResource
{
	public required string Login { get; set; }
	public required string Senha { get; set; }

	public required ICollection<ReferenceRoleResource> Funcoes { get; set; }
}
