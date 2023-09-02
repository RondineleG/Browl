namespace Browl.Service.MarketDataCollector.Domain.Dtos.Usuario;

public class UsuarioView
{
    public string Login { get; set; }

    public ICollection<FuncaoView> Funcoes { get; set; }
}