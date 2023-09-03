using Browl.Application.Features.Brands.Queries.GetAll;
using Browl.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Browl.Application.Features.Brands.Commands.AddEdit;

namespace Browl.Client.Infrastructure.Managers.Catalog.Brand
{
    public interface IBrandManager : IManager
    {
        Task<IResult<List<GetAllBrandsResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditBrandCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}