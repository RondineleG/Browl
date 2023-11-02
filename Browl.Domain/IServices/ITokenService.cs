using Browl.Domain.Models;

namespace Browl.Domain.IServices;
public interface ITokenService
{
	Task<string> GenerateToken(User user);
}
