using Browl.Application.Features.Products.Commands.AddEdit;
using Browl.Application.Features.Products.Queries.GetAllPaged;
using Browl.Application.Requests.Catalog;
using Browl.Shared.Wrapper;
using System.Threading.Tasks;

namespace Browl.Client.Infrastructure.Managers.Catalog.Product
{
    public interface IProductManager : IManager
    {
        Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

        Task<IResult<string>> GetProductImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditProductCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}