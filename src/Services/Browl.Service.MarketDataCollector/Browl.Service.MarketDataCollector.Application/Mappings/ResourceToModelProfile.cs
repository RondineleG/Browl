using AutoMapper;

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
		var unused2 = CreateMap<CategorySaveResource, Category>();

		var unused1 = CreateMap<ProductSaveResource, Product>()
			.ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => (UnitOfMeasurement)src.UnitOfMeasurement));

		var unused = CreateMap<ProductsQueryResource, ProductsQuery>();
	}
}
