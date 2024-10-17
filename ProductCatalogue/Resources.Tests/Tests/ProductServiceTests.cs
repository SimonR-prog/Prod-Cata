using Moq;
using Resources.Interface;
using Resources.Models;

namespace Resources.Tests.Tests;

public class ProductServiceTests
{
    private readonly Mock<IProductService<Product, Product>> _productServiceMock = new();

    [Fact]
    public void CreateAndAddProduct__ShouldReturnSuccessTrue__WhenProductIsCreatedAndAdded()
    {
        //Arrange
        var product = new Product("Tomat", 12m);
        var wantedResponse = new Response<Product> { Succeeded = true , Message = $"{product.ProductName} was added." , Content = product};

        var productList = new List<Product>();

        _productServiceMock.Setup(productService => productService.AddToList(product))
            .Callback<Product>(p => productList.Add(p))
            .Returns(wantedResponse);
        var productService = _productServiceMock.Object;

        //Act
        var result = productService.AddToList(product);

        //Assert
        Assert.True(result.Succeeded);
        Assert.Equal(product, result.Content);
        Assert.Contains(product, productList);
    }








}
