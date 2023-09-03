using AutoMapper;
using Browl.Application.Features.DocumentTypes.Commands.AddEdit;
using Browl.Application.Features.DocumentTypes.Queries.GetAll;
using Browl.Application.Features.DocumentTypes.Queries.GetById;
using Browl.Domain.Entities.Misc;

namespace Browl.Application.Mappings
{
    public class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            CreateMap<AddEditDocumentTypeCommand, DocumentType>().ReverseMap();
            CreateMap<GetDocumentTypeByIdResponse, DocumentType>().ReverseMap();
            CreateMap<GetAllDocumentTypesResponse, DocumentType>().ReverseMap();
        }
    }
}