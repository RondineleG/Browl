using AutoMapper;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Extensions;
using Browl.Service.MarketDataCollector.Domain.Queries.Base;
using Browl.Service.MarketDataCollector.Domain.Resources.Category;
using Browl.Service.MarketDataCollector.Domain.Resources.Product;
using Browl.Service.MarketDataCollector.Domain.Resources.Query;

namespace Browl.Service.MarketDataCollector.Application.Mappings
{
	public class ModelToResourceProfile : Profile
	{
		public ModelToResourceProfile()
		{
			_ = CreateMap<Category, CategoryResource>();

			_ = CreateMap<Product, ProductResource>()
				.ForMember(src => src.UnitOfMeasurement,
						   opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));

			_ = CreateMap<QueryResult<Product>, QueryResultResource<ProductResource>>();
		}
	}
}