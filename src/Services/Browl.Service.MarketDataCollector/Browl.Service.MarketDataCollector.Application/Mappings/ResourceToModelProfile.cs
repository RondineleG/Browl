using AutoMapper;
<<<<<<< HEAD

using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Enums;
using Browl.Service.MarketDataCollector.Domain.Queries;
using Browl.Service.MarketDataCollector.Domain.Resources.Category;
using Browl.Service.MarketDataCollector.Domain.Resources.Product;

namespace Browl.Service.MarketDataCollector.Application.Mappings;

public class ResourceToModelProfile : Profile
{
	public ResourceToModelProfile()
	{
		_ = CreateMap<CategorySaveResource, Category>();

		_ = CreateMap<ProductSaveResource, Product>()
			.ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => (UnitOfMeasurement)src.UnitOfMeasurement));

		_ = CreateMap<ProductsQueryResource, ProductsQuery>();
	}
=======
using Browl.Service.MarketDataCollector.Application.Resources;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Enums;
using Browl.Service.MarketDataCollector.Domain.Queries;

namespace Browl.Service.MarketDataCollector.Application.Mappings
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CategorySaveResource, Category>();

            CreateMap<ProductSaveResource, Product>()
                .ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => (UnitOfMeasurement)src.UnitOfMeasurement));

            CreateMap<ProductsQueryResource, ProductsQuery>();
        }
    }
>>>>>>> dev
}