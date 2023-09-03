using AutoMapper;
using Browl.Application.Features.Documents.Commands.AddEdit;
using Browl.Application.Features.Documents.Queries.GetById;
using Browl.Domain.Entities.Misc;

namespace Browl.Application.Mappings
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
            CreateMap<GetDocumentByIdResponse, Document>().ReverseMap();
        }
    }
}