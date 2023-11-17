using Athena.Core.Interfaces;
using Athena.Core.Services;
using FakeItEasy;

namespace Athena.Tests
{
    public class ProductServiceTests
    {
        private ProductsService _sut;
        private IAthenaDbContext _athenaDbContext;

        public ProductServiceTests()
        {
            _athenaDbContext = A.Fake<IAthenaDbContext>();

            _sut = new ProductsService(_athenaDbContext);
        }

        [Fact]
        public async Task GetProductsAsync_ShouldReturnListOfProducts_WhenProductsExist()
        {
            // Arrange
            var expectedProducts = new List<Product>()
            {
                new Product() { Id = 1, Name = "Product 1" },
                new Product() { Id = 2, Name = "Product 2" },
                new Product() { Id = 3, Name = "Product 3" }
            };

            A.CallTo(() => _athenaDbContext.Products).Returns(expectedProducts);

            // Act
            var result = await _sut.GetProductsAsync();

            // Assert
            result.Should().BeEquivalentTo(expectedProducts);
        }

        [Fact]
        public async Task GetProductsAsync_ShouldReturnEmptyListOfProducts_WhenNoProductsExist()
        {
            // Arrange
            var expectedProducts = new List<Product>();

            A.CallTo(() => _athenaDbContext.Products).Returns(expectedProducts);

            // Act
            var result = await _sut.GetProductsAsync();

            // Assert
            result.Should().BeEquivalentTo(expectedProducts);
        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var expectedProduct = new Product() { Id = 1, Name = "Product 1" };

            A.CallTo(() => _athenaDbContext.Products).Returns(expectedProduct);

            // Act
            var result = await _sut.GetProductByIdAsync(1);

            // Assert
            result.Should().BeEquivalentTo(expectedProduct);
        }

    }
}