
namespace ProductCatalogue.Menues;

internal class MainMenu
{
    private readonly ProductMenu _productMenu = new ProductMenu();
    public void StartMenu()
    {   
        Console.Clear();
        Console.WriteLine("Menu;");
        Console.WriteLine("1. Create a product.");
        Console.WriteLine("2. Show product list.");
        Console.WriteLine("3. Remove a product.");
        Console.WriteLine("4. Add old text file of products into program.");
        Console.WriteLine("0. Exit program.");
        Console.Write("Enter an option; ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                _productMenu.CreateProductMenu();
                break;
            case "2":
                _productMenu.ShowProductsMenu();
                break;
            case "3":
                _productMenu.DeleteProductMenu();
                break;
            case "4":
                _productMenu.AddOldList();
                break;
            case "0":
                Console.WriteLine("Ending program.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid input.");
                Console.ReadKey();
                break;
        }
    }
}
