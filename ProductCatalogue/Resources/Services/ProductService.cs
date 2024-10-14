using Newtonsoft.Json;
using Resources.Interface;
using Resources.Models;


namespace Resources.Services;

public class ProductService : IProductService<Product, Product>
{
    private readonly IFileService _fileService;
    private List<Product> _products;

    public ProductService(string filePath)
    {
        _fileService = new FileService(filePath);
        _products = [];
        GetAllProducts();
    }

    public Response<Product> AddToList(Product product)
    {
        try
        {
            if (string.IsNullOrEmpty(product.ProductName) || string.IsNullOrEmpty(product.ProductId) || product.ProductPrice <= 0)
            {
                return new Response<Product>
                {
                    Succeeded = false,
                    Message = "One or more parameters of a product was invalid."
                };
            }

            _products.Add(product);

            var json = JsonConvert.SerializeObject(_products, Formatting.Indented);
            var result = _fileService.SaveToFile(json);

            if (result.Succeeded)
            {
                return new Response<Product>
                {
                    Succeeded = true,
                    Message = "Product was added."
                };
            }
            else
            {
                return new Response<Product>
                {
                    Succeeded = false,
                    Message = $"{product.ProductName} was not added."
                };
            }
        }
        catch (Exception ex)
        {
            return new Response<Product>
            {
                Succeeded = false,
                Message = ex.Message
            };
        }
    }

    public Response<IEnumerable<Product>> GetAllProducts()
    {
        try
        {
            var result = _fileService.GetFromFile();

            if (result.Succeeded)
            {
                _products = JsonConvert.DeserializeObject<List<Product>>(result.Content!)!;
                return new Response<IEnumerable<Product>>
                {
                    Succeeded = true,
                    Content = _products
                };
            }
            else
            {
                return new Response<IEnumerable<Product>>
                {
                    Succeeded = false,
                    Message = "Something went wrong with getting the list."
                };
            }
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<Product>>
            { 
                Succeeded = false, 
                Message = ex.Message 
            };
        }
    }

    public Response<Product> DeleteProduct(string id)
    {
        try
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            Console.WriteLine($"{id}");
            Console.ReadKey();
            if (product == null)
            {
                return new Response<Product>
                {
                    Succeeded = false,
                    Message = "Product does not exist."
                };
            }

            _products.Remove(product);

            var json = JsonConvert.SerializeObject(_products, Formatting.Indented);
            var result = _fileService.SaveToFile(json);
            if (result.Succeeded)
            {
                return new Response<Product>
                {
                    Succeeded = true,
                    Message = "Fuck you."
                };
            }
            else 
            { 
                return new Response<Product> 
                { 
                    Succeeded = false, 
                    Message = result.Message 
                }; 
            }
        }
        catch (Exception ex)
        {
            return new Response<Product>
            {
                Succeeded = false,
                Message = ex.Message
            };
        }
    }
}
