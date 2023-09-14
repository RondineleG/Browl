namespace Browl.Service.MarketDataCollector.Domain.Resources.User;

public class UserViewResource
{
<<<<<<< HEAD
	public required string Login { get; set; }
	public required ICollection<RoleViewResource> Funcoes { get; set; }
=======
    public string Login { get; set; }

    public ICollection<RoleViewResource> Funcoes { get; set; }
>>>>>>> dev
}