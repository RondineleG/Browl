using AutoMapper;
using Browl.Application.Features.ExtendedAttributes.Commands.AddEdit;
using Browl.Application.Features.ExtendedAttributes.Queries.GetAll;
using Browl.Application.Features.ExtendedAttributes.Queries.GetAllByEntityId;
using Browl.Application.Features.ExtendedAttributes.Queries.GetById;
using Browl.Domain.Entities.ExtendedAttributes;

namespace Browl.Application.Mappings
{
    public class ExtendedAttributeProfile : Profile
    {
        public ExtendedAttributeProfile()
        {
            CreateMap(typeof(AddEditExtendedAttributeCommand<,,,>), typeof(DocumentExtendedAttribute))
                .ForMember(nameof(DocumentExtendedAttribute.Entity), opt => opt.Ignore())
                .ForMember(nameof(DocumentExtendedAttribute.CreatedBy), opt => opt.Ignore())
                .ForMember(nameof(DocumentExtendedAttribute.CreatedOn), opt => opt.Ignore())
                .ForMember(nameof(DocumentExtendedAttribute.LastModifiedBy), opt => opt.Ignore())
                .ForMember(nameof(DocumentExtendedAttribute.LastModifiedOn), opt => opt.Ignore());

            CreateMap(typeof(GetExtendedAttributeByIdResponse<,>), typeof(DocumentExtendedAttribute)).ReverseMap();
            CreateMap(typeof(GetAllExtendedAttributesResponse<,>), typeof(DocumentExtendedAttribute)).ReverseMap();
            CreateMap(typeof(GetAllExtendedAttributesByEntityIdResponse<,>), typeof(DocumentExtendedAttribute)).ReverseMap();
        }
    }
}