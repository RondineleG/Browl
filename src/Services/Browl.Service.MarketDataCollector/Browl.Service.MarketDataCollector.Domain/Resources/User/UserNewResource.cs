namespace Browl.Service.MarketDataCollector.Domain.Resources.User;

public class UserNewResource
{
<<<<<<< HEAD
	public required string Login { get; set; }
	public required string Senha { get; set; }
	public required ICollection<ReferenceRoleResource> Funcoes { get; set; }
=======
    public string Login { get; set; }
    public string Senha { get; set; }

    public ICollection<ReferenceRoleResource> Funcoes { get; set; }
>>>>>>> dev
}