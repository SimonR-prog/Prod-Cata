namespace Resources.Models;
public class Product
{
    public string ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal ProductPrice { get; set; }

    public Product(string productName, decimal productPrice)
    {
        ProductId = Guid.NewGuid().ToString();
        ProductName = productName;
        ProductPrice = productPrice;
    }
}

