using System.Threading.Tasks;

namespace Browl.Service.DataNormalization.Application.Services
{
    public interface IPackingListReadService
    {
        Task<bool> ExistsByNameAsync(string name);
    }
}