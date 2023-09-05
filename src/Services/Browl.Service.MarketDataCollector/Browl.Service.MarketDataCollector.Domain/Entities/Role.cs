namespace Browl.Service.MarketDataCollector.Domain.Entities;
public class Role
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public ICollection<User> Usuarios { get; set; }
}