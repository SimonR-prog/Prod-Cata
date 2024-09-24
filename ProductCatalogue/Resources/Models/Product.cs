namespace Resources.Models;
public class Product
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string ProductName { get; set; } = null!;
    public string Price { get; set; } = null!;
}

