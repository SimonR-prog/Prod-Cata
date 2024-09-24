
namespace ProductCatalogue.Menues;

internal static class MainMenu
{
    public static void DisplayMenu()
    {   
        Console.Clear();
        Console.WriteLine("Menu;");
        Console.WriteLine("1. Show productlist.");
        Console.WriteLine("2. Create a product.");
        Console.WriteLine("3. Change a product.");
        Console.WriteLine("4. Remove a product.");
        Console.WriteLine("5. Add old text file of products into program.");
        Console.WriteLine("0. Exit program.");
        Console.Write("Enter an option; ");

        ProductMenu.ProductMenuChoice();

    }
}
