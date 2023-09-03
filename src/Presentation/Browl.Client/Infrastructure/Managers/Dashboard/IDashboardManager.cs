using Browl.Application.Features.Dashboards.Queries.GetData;
using Browl.Shared.Wrapper;
using System.Threading.Tasks;

namespace Browl.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}