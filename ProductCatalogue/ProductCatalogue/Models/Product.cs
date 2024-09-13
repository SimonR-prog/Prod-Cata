
namespace ProductCatalogue.Models;

public class Product
{
    public Guid Id { get; private set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }


    //Constructor initialize.
    public Product(string productName, decimal price)
    {
        Id = Guid.NewGuid();
        ProductName = productName;
        Price = price;
    }

}



