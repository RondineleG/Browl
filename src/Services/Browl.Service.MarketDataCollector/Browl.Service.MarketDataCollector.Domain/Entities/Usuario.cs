namespace Browl.Service.MarketDataCollector.Domain.Entities;
public class Usuario
{
    public string Login { get; set; }
    public string Senha { get; set; }

    public ICollection<Funcao> Funcoes { get; set; }

    public Usuario()
    {
        Funcoes = new HashSet<Funcao>();
    }
}