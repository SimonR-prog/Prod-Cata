using ProductCatalogue.Menues;
using Resources.Interface;
using Resources.Models;
using Resources.Services;
using System.Runtime.CompilerServices;



//IProductService<Product, Product> productService = new ProductService(Path.Combine(Directory.GetCurrentDirectory(), "currentProductList.json"));

while (true)
{
    MainMenu mainMenu = new MainMenu();
    mainMenu.StartMenu();
    Console.WriteLine("Press enter to continue.");
    Console.ReadKey();
}
