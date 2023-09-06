using Browl.Service.MarketDataCollector.Domain.Communication;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;

namespace Browl.Service.MarketDataCollector.Application.Services.Facts
{
	public class CategoryServiceTest
	{
		private readonly ICategoryService _categoryService;
		private readonly Mock<ICategoryRepository> _mockCategoryRepository;
		private readonly Mock<IUnitOfWork> _mockUnitOfWork;
		private readonly Mock<IMemoryCache> _mockCache;
		private readonly Mock<ILogger<CategoryService>> _mockLogger;

		public CategoryServiceTest()
		{
			_mockCategoryRepository = new Mock<ICategoryRepository>();
			_mockUnitOfWork = new Mock<IUnitOfWork>();
			_mockCache = new Mock<IMemoryCache>();
			_mockLogger = new Mock<ILogger<CategoryService>>();
			_categoryService = new CategoryService(_mockCategoryRepository.Object, _mockUnitOfWork.Object, _mockCache.Object, _mockLogger.Object);
		}

		[Fact]
		public async Task ListAsync_ReturnsCategories_WhenCacheIsEmpty()
		{
			// Arrange
			List<Category> categories = new List<Category>()
	{
		new Category { Id = 1, Name = "Category 1" },
		new Category { Id = 2, Name = "Category 2" },
	};

			var cacheKey = "your_cache_key"; // Replace with your actual cache key
			var cacheEntry = new Mock<ICacheEntry>();
			cacheEntry.SetupProperty(e => e.Value);

			_mockCache.Setup(c => c.CreateEntry(It.IsAny<object>())).Returns(cacheEntry.Object);

			_mockCategoryRepository.Setup(r => r.ListAsync()).ReturnsAsync(categories);

			// Act
			var result = await _categoryService.ListAsync();

			// Assert
			Assert.Equal(categories, result);

			_mockCache.Verify(c => c.CreateEntry(It.IsAny<object>()), Times.Once);
			_mockCategoryRepository.Verify(r => r.ListAsync(), Times.Once);
		}

		[Fact]
		public async Task SaveAsync_ReturnsResponseWithCategory_WhenCategoryIsSavedSuccessfully()
		{
			// Arrange
			Category category = new Category { Id = 1, Name = "Category 1" };

			_mockCategoryRepository.Setup(r => r.AddAsync(category)).Verifiable();
			_mockUnitOfWork.Setup(u => u.CompleteAsync()).Returns(Task.CompletedTask).Verifiable();

			// Act
			var result = await _categoryService.SaveAsync(category);

			// Assert
			Assert.Equal(new Response<Category>(category), result);
			_mockCategoryRepository.Verify(r => r.AddAsync(category), Times.Once);
			_mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
		}

		[Fact]
		public async Task SaveAsync_ReturnsErrorResponse_WhenAnErrorOccursWhileSavingCategory()
		{
			// Arrange
			Category category = new Category { Id = 1, Name = "Category 1" };
			string errorMessage = "An error occurred.";

			_mockCategoryRepository.Setup(r => r.AddAsync(category)).ThrowsAsync(new Exception());
			_mockLogger.Setup(l => l.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();

			// Act
			var result = await _categoryService.SaveAsync(category);

			// Assert
			Assert.Equal(new Response<Category>(errorMessage), result);
			_mockCategoryRepository.Verify(r => r.AddAsync(category), Times.Once);
			_mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Never);
			_mockLogger.Verify(l => l.LogError(It.IsAny<Exception>(), It.IsAny<string>()), Times.Once);
		}



	}
}


