using Resources.Models;

namespace Resources.Interface;

public interface IProductService<T, TResult> where T : class where TResult : class
{
    Response<TResult> CreateProduct(T product);
    Response<IEnumerable<TResult>> GetAllProducts();
    Response<TResult> GetAProduct(string id);
    Response<TResult> UpdateProduct(string id, T updatedProduct);
    Response<TResult> DeleteProduct(string id);
}
