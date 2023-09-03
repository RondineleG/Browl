using Browl.Service.MarketDataCollector.Domain.Dtos.Usuario;
using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;

public interface IUsuarioManager
{
    Task<IEnumerable<UsuarioView>> GetAsync();

    Task<UsuarioView> GetAsync(string login);

    Task<UsuarioView> InsertAsync(NovoUsuario usuario);

    Task<UsuarioView> UpdateMedicoAsync(Usuario usuario);

    Task<UsuarioLogado> ValidaUsuarioEGeraTokenAsync(Usuario usuario);
}