namespace Browl.Service.MarketDataCollector.Domain.Resources.User;

public class UserNewResource
{
    public string Login { get; set; }
    public string Senha { get; set; }

    public ICollection<ReferenceRoleResource> Funcoes { get; set; }
}