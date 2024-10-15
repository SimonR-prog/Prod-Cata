using Resources.Interface;
using Resources.Models;
using Resources.Services;

namespace ProductCatalogue.Menues;

internal class ProductMenu
{
    private readonly ProductService _productService = new ProductService(Path.Combine(Directory.GetCurrentDirectory(), "currentProductList.json"));

    public void CreateProductMenu()
    {
        Console.Clear();
        Console.WriteLine("Create new product; ");

        Console.Write("Product name > ");
        string productName = Console.ReadLine() ?? "";
        
        Console.Write("Product price > ");
        string productPriceString = Console.ReadLine() ?? "";
        decimal productPrice;
        //Turning price into decimal.
        while (!decimal.TryParse(productPriceString, out productPrice))
        {
            Console.WriteLine("Invalid price. Must enter a valid decimal number.");
            Console.Write("Enter a new price; ");
            productPriceString = Console.ReadLine() ?? "";
        }
        
        Product product = new Product(productName, productPrice);
        var result = _productService.AddToList(product);

        if (result.Succeeded)
        {
            Console.WriteLine($"{result.Message}");
        }
        else
        {
            Console.WriteLine($"{result.Message}");
        }
    }

    public void ShowProductsMenu()
    {
        //Add a try catch?
        Console.Clear();
        var result = _productService.GetAllProducts();

        if (result.Succeeded)
        {
            IEnumerable<Product>? content = result.Content;
            if (content != null)
            {
                Console.WriteLine("Products; ");
                foreach (Product product in content)
                {
                    Console.WriteLine($"{product.ProductName.PadRight(15)}{product.ProductPrice}{product.ProductId.PadLeft(45)}");
                }
            }
        }
        else
        {
            Console.WriteLine("Something went wrong with the list.");
        }
    }
    public void DeleteProductMenu() 
    {
        Console.Clear();
        Console.WriteLine("Delete product; ");
        Console.Write("What is the products id? > ");
        string delete = (Console.ReadLine() ?? "");

        var result = _productService.DeleteProduct(delete);
        if (result.Succeeded)
        {
            Console.Clear();
            Console.WriteLine($"{result.Message}");
        }
        else
        {
            Console.WriteLine($"{result.Message}");
        }
    }

    public void AddOldList()
    {
        Console.Clear();
        Console.Write("Filepath > ");
        string secondaryFilePath = (Console.ReadLine() ?? "");

        var result = _productService.AddOldList(secondaryFilePath);
    }

}