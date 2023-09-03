using Browl.Application.Features.Documents.Commands.AddEdit;
using Browl.Application.Features.Documents.Queries.GetAll;
using Browl.Application.Features.Documents.Queries.GetById;
using Browl.Application.Requests.Documents;
using Browl.Shared.Wrapper;
using System.Threading.Tasks;

namespace Browl.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}