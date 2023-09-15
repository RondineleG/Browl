namespace Browl.Service.MarketDataCollector.Domain.Entities;
public class Role
{
	public int Id { get; set; }
	public required string Descricao { get; set; }

	public required ICollection<User> Usuarios { get; set; }
}
