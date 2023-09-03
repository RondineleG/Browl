using AutoMapper;
using Browl.Application.Features.Brands.Commands.AddEdit;
using Browl.Application.Features.Brands.Queries.GetAll;
using Browl.Application.Features.Brands.Queries.GetById;
using Browl.Domain.Entities.Catalog;

namespace Browl.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}