using AutoMapper;
using Browl.Application.Features.Products.Commands.AddEdit;
using Browl.Domain.Entities.Catalog;

namespace Browl.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}