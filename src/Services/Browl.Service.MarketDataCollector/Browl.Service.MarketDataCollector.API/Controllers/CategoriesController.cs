using AutoMapper;

using Browl.Service.MarketDataCollector.API.Configurations.MainController;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Browl.Service.MarketDataCollector.Domain.Resources.Category;
using Browl.Service.MarketDataCollector.Domain.Resources.Erro;

using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.MarketDataCollector.API.Controllers;

public class CategoriesController : MainController
{
	private readonly ICategoryService _categoryService;
	private readonly IMapper _mapper;

	public CategoriesController(ICategoryService categoryService, IMapper mapper)
	{
		_categoryService = categoryService;
		_mapper = mapper;
	}

	/// <summary>
	/// Lists all categories.
	/// </summary>
	/// <returns>List os categories.</returns>
	[HttpGet]
	[ProducesResponseType(typeof(IEnumerable<CategoryResource>), 200)]
	public async Task<IEnumerable<CategoryResource>> ListAsync()
	{
		var categories = await _categoryService.ListAsync();
		return _mapper.Map<IEnumerable<CategoryResource>>(categories);
	}

	/// <summary>
	/// Saves a new category.
	/// </summary>
	/// <param name="resource">Category data.</param>
	/// <returns>Response for the request.</returns>
	[HttpPost]
	[ProducesResponseType(typeof(CategoryResource), 201)]
	[ProducesResponseType(typeof(ErrorResource), 400)]
	public async Task<IActionResult> PostAsync([FromBody] CategorySaveResource resource)
	{
		var category = _mapper.Map<Category>(resource);
		var result = await _categoryService.SaveAsync(category);

		if (!result.Success)
		{
			return BadRequest(new ErrorResource(result.Message!));
		}

		var categoryResource = _mapper.Map<CategoryResource>(result.Resource!);
		return Ok(categoryResource);
	}

	/// <summary>
	/// Updates an existing category according to an identifier.
	/// </summary>
	/// <param name="id">Category identifier.</param>
	/// <param name="resource">Updated category data.</param>
	/// <returns>Response for the request.</returns>
	[HttpPut("{id}")]
	[ProducesResponseType(typeof(CategoryResource), 200)]
	[ProducesResponseType(typeof(ErrorResource), 400)]
	public async Task<IActionResult> PutAsync(int id, [FromBody] CategorySaveResource resource)
	{
		var category = _mapper.Map<Category>(resource);
		var result = await _categoryService.UpdateAsync(id, category);

		if (!result.Success)
		{
			return BadRequest(new ErrorResource(result.Message!));
		}

		var categoryResource = _mapper.Map<CategoryResource>(result.Resource!);
		return Ok(categoryResource);
	}

	/// <summary>
	/// Deletes a given category according to an identifier.
	/// </summary>
	/// <param name="id">Category identifier.</param>
	/// <returns>Response for the request.</returns>
	[HttpDelete("{id}")]
	[ProducesResponseType(typeof(CategoryResource), 200)]
	[ProducesResponseType(typeof(ErrorResource), 400)]
	public async Task<IActionResult> DeleteAsync(int id)
	{
		var result = await _categoryService.DeleteAsync(id);

		if (!result.Success)
		{
			return BadRequest(new ErrorResource(result.Message!));
		}

		var categoryResource = _mapper.Map<CategoryResource>(result.Resource!);
		return Ok(categoryResource);
	}
}
