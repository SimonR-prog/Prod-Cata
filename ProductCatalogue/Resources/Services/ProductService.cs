using Resources.Interface;
using Resources.Models;

namespace Resources.Services;

public class ProductService : IProductService<Product, Product>
{
    public Response<Product> CreateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Response<IEnumerable<Product>> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Response<Product> GetAProduct(string id)
    {
        throw new NotImplementedException();
    }

    public Response<Product> UpdateProduct(string id, Product updatedProduct)
    {
        throw new NotImplementedException();
    }

    public Response<Product> DeleteProduct(string id)
    {
        throw new NotImplementedException();
    }
}
