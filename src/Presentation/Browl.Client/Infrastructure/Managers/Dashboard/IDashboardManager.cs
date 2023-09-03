using Browl.Shared.Wrapper;
using System.Threading.Tasks;
using Browl.Application.Features.Dashboards.Queries.GetData;

namespace Browl.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}