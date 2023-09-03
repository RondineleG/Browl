using Browl.Application.Interfaces.Common;

namespace Browl.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}