namespace Browl.Service.MarketDataCollector.Domain.Entities;
public class Role
{
<<<<<<< HEAD
	public int Id { get; set; }
	public required string Descricao { get; set; }

	public required ICollection<User> Usuarios { get; set; }
=======
    public int Id { get; set; }
    public string Descricao { get; set; }

    public ICollection<User> Usuarios { get; set; }
>>>>>>> dev
}