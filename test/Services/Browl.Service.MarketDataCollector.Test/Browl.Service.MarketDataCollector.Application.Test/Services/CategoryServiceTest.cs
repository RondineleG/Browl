using AutoMapper;

using Browl.Service.MarketDataCollector.Application.Mappings;
using Browl.Service.MarketDataCollector.Application.Services;
using Browl.Service.MarketDataCollector.Application.Test.Builders;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Browl.Service.MarketDataCollector.Domain.Resources.Category;
using Browl.Service.MarketDataCollector.FakeData.CategoryData;

using FluentAssertions;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

using NSubstitute;

namespace Browl.Service.MarketDataCollector.Application.Test.Services;

public class CategoryServiceTest
{
	private readonly ICategoryService _categoryService;
	private readonly ICategoryRepository _categoryRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly IMemoryCache _memoryCache;
	private readonly ILogger<CategoryService> logger;
	private readonly Category Category;
	private readonly CategoryFaker _categoryFaker;
	public CategoryServiceTest()
	{
		_categoryRepository = Substitute.For<ICategoryRepository>();
		_unitOfWork = Substitute.For<IUnitOfWork>();
		_mapper = new MapperConfiguration(p => p.AddProfile<ModelToResourceProfile>()).CreateMapper();
		_memoryCache = Substitute.For<IMemoryCache>();
		logger = Substitute.For<ILogger<CategoryService>>();
		_categoryService = new CategoryService(_categoryRepository, _unitOfWork, _memoryCache, logger);
		_categoryFaker = new CategoryFaker();
		Category = _categoryFaker.Generate();
	}

	[Fact]
	public async Task AddNewCategory()
	{
		// Arrange
		CategoryResourceBuilder resourceBuilder = new();
		var categoryResource = resourceBuilder.BuildResource();
		Category category = new(categoryResource);

		// Act
		_ = await _categoryService.SaveAsync(category);

		// Assert
		await _categoryRepository.Received(1).AddAsync(Arg.Is<Category>(c =>
			c.Id == categoryResource.Id &&
			c.Name == categoryResource.Name));
	}
	[Fact]
	public async Task InsertClienteAsync_Sucesso()
	{
		var controle = _mapper.Map<CategoryResource>(Category);
		var retorno = await _categoryService.SaveAsync(Category); ;

		await _categoryRepository.Received().AddAsync(Arg.Any<Category>());

		_ = retorno.Should().BeEquivalentTo(controle);
	}
}


