using Browl.Core.Entities;

namespace Browl.Core.Interfaces.Services;

public interface IJwtService
{
    string GerarToken(Usuario usuario);
}