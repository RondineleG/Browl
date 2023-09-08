using AutoMapper;
using Browl.Service.MarketDataCollector.API.Configurations.MainController;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Browl.Service.MarketDataCollector.Domain.Queries;
using Browl.Service.MarketDataCollector.Domain.Resources.Erro;
using Browl.Service.MarketDataCollector.Domain.Resources.Product;
using Browl.Service.MarketDataCollector.Domain.Resources.Query;
using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.MarketDataCollector.API.Controllers
{
	public class ProductsController : MainController
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductsController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		/// <summary>
		/// Lists all existing products according to query filters.
		/// </summary>
		/// <returns>List of products.</returns>
		[HttpGet]
		[ProducesResponseType(typeof(QueryResultResource<ProductResource>), 200)]
		public async Task<QueryResultResource<ProductResource>> ListAsync([FromQuery] ProductsQueryResource query)
		{
			ProductsQuery productsQuery = _mapper.Map<ProductsQuery>(query);
			Domain.Queries.Base.QueryResult<Product> queryResult = await _productService.ListAsync(productsQuery);

			return _mapper.Map<QueryResultResource<ProductResource>>(queryResult);
		}

		/// <summary>
		/// Saves a new product.
		/// </summary>
		/// <param name="resource">Product data.</param>
		/// <returns>Response for the request.</returns>
		[HttpPost]
		[ProducesResponseType(typeof(ProductResource), 201)]
		[ProducesResponseType(typeof(ErrorResource), 400)]
		public async Task<IActionResult> PostAsync([FromBody] ProductSaveResource resource)
		{
			Product product = _mapper.Map<Product>(resource);
			Domain.Communication.Response<Product> result = await _productService.SaveAsync(product);

			if (!result.Success)
			{
				return BadRequest(new ErrorResource(result.Message!));
			}

			ProductResource productResource = _mapper.Map<ProductResource>(result.Resource!);
			return Ok(productResource);
		}

		/// <summary>
		/// Updates an existing product according to an identifier.
		/// </summary>
		/// <param name="id">Product identifier.</param>
		/// <param name="resource">Product data.</param>
		/// <returns>Response for the request.</returns>
		[HttpPut("{id}")]
		[ProducesResponseType(typeof(ProductResource), 201)]
		[ProducesResponseType(typeof(ErrorResource), 400)]
		public async Task<IActionResult> PutAsync(int id, [FromBody] ProductSaveResource resource)
		{
			Product product = _mapper.Map<Product>(resource);
			Domain.Communication.Response<Product> result = await _productService.UpdateAsync(id, product);

			if (!result.Success)
			{
				return BadRequest(new ErrorResource(result.Message!));
			}

			ProductResource productResource = _mapper.Map<ProductResource>(result.Resource!);
			return Ok(productResource);
		}

		/// <summary>
		/// Deletes a given product according to an identifier.
		/// </summary>
		/// <param name="id">Product identifier.</param>
		/// <returns>Response for the request.</returns>
		[HttpDelete("{id}")]
		[ProducesResponseType(typeof(ProductResource), 200)]
		[ProducesResponseType(typeof(ErrorResource), 400)]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			Domain.Communication.Response<Product> result = await _productService.DeleteAsync(id);

			if (!result.Success)
			{
				return BadRequest(new ErrorResource(result.Message!));
			}

			ProductResource categoryResource = _mapper.Map<ProductResource>(result.Resource!);
			return Ok(categoryResource);
		}
	}
}