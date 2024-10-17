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
            if (string.IsNullOrEmpty(product.ProductName) || string.IsNullOrEmpty(product.ProductId) || product.ProductPrice <= 0m)
            {
                return new Response<Product>
                {
                    Succeeded = false,
                    Message = $"Productname; {product.ProductName}, productprice {product.ProductPrice} or product id {product.ProductId} is invalid."
                };
            }
            
            if (_products.Any(pN => string.Equals(pN.ProductName, product.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                return new Response<Product>
                {
                    Succeeded = false,
                    Message = $"{product.ProductName} is already on the list."
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
                    Message = $"{product.ProductName} was added."
                };
            }
            return new Response<Product>
            {
                Succeeded = false,
                Message = $"{product.ProductName} was not added."
            };
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
        if (string.IsNullOrEmpty(id))
            return new Response<Product>
            {
                Succeeded = false,
                Message = "Must input a valid id."
            };

        try
        {
            var productToRemove = _products.ToList().FirstOrDefault(p => p.ProductId == id);
            if (productToRemove == null)
            {
                return new Response<Product>
                {
                    Succeeded = false,
                    Message = "Product does not exist."
                };
            }
            
            _products.Remove(productToRemove);

            var json = JsonConvert.SerializeObject(_products, Formatting.Indented);
            var result = _fileService.SaveToFile(json);
            if (result.Succeeded)
            {
                return new Response<Product>
                {
                    Succeeded = true,
                    Message = $"{productToRemove.ProductName} was removed."
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
    /*
    public Response<Product> AddOldList(List<Product>)
    {
        //Send new string of a filepath to the fileservice and store in a new list.

        //Use a foreach loop to add each product using the addtolist() method?

        //if the product was invalid and not added?
        //If the product is already in the list?


        Console.WriteLine($"{oldFilePath}");
        Console.ReadKey();

        return new Response<Product>
        {
            Succeeded = true,
            Message = ""

        };


    }
    */
}
