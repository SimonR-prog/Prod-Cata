namespace Resources.Models;
public class Product
{
    public string ProductId { get; private set; } = Guid.NewGuid().ToString();
    public string ProductName { get; set; } = null!;
    public decimal ProductPrice { get; set; }

    public Product(string productName, decimal productPrice)
    {
        ProductName = productName;
        ProductPrice = productPrice;
    }
}

