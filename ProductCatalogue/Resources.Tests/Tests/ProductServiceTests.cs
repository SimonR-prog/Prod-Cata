using Moq;
using Resources.Interface;
using Resources.Models;
using Resources.Services;

namespace Resources.Tests.Tests;

public class ProductServiceTests
{
    [Fact]
    public void AddToList_ShouldReturnTrueResponse()
    {
        //Arrange
        var mockFileService = new Mock<IFileService>();

        mockFileService.Setup(fs => fs.SaveToFile(It.IsAny<string>()))
            .Returns(new Response<string> { Succeeded = true });

        var productService = new ProductService(mockFileService.Object);

        string productId = Guid.NewGuid().ToString();
        var product = new Product(productId, "Tomat", 5m);

        //Act;
        var result = productService.AddToList(product);

        //Assert;
        Assert.True(result.Succeeded);
        Assert.Equal($"{product.ProductName} was added.", result.Message);

        mockFileService.Verify(fs => fs.SaveToFile(It.IsAny<string>()), Times.Once);
    }
}
