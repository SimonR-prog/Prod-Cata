using Resources.Models;

namespace Resources.Interface;

public interface IProductService<T, TResult> where T : class where TResult : class
{
    Response<TResult> AddToList(T product);
    Response<IEnumerable<TResult>> GetAllProducts();
    Response<TResult> DeleteProduct(string id);
}
