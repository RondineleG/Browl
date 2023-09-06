using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Browl.Service.MarketDataCollector.Application.Services;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Xunit;

namespace Browl.Service.MarketDataCollector.Application.Test.Services
{
    public class CategoryServiceTests
    {
        private readonly ICategoryService _categoryService;

        public CategoryServiceTests(ICategoryService categoryService)
        {
            // Initialize the category service instance
            _categoryService = categoryService;
        }

        [Fact]
        public async Task ListAsync_ShouldReturnListOfCategories()
        {
            // Act
            var result = await _categoryService.ListAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Category>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task SaveAsync_ShouldSaveCategory()
        {
            // Arrange
            var category = new Category { Name = "Test Category" };

            // Act
            var result = await _categoryService.SaveAsync(category);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateCategory()
        {
            // Arrange
            var categoryId = 1;
            var updatedCategory = new Category { Id = categoryId, Name = "Updated Category" };

            // Act
            var result = await _categoryService.UpdateAsync(categoryId, updatedCategory);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteCategory()
        {
            // Arrange
            var categoryId = 1;

            // Act
            var result = await _categoryService.DeleteAsync(categoryId);

            // Assert
            Assert.NotNull(result);
        }
    }
}
