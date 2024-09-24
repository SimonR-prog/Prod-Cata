
using System.Text.Json.Serialization;

namespace ProductCatalogue.Menues;

internal class ProductMenu
{
    internal static void ProductMenuChoice()
    {
        if (int.TryParse(Console.ReadLine(), out int choice)) {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("1");

                    break;

                case 2:

                    Console.Clear();
                    Console.ReadKey();


                    break;

                case 3:
                    Console.WriteLine("3");
                    break;

                case 4:
                    Console.WriteLine("4");
                    break;

                case 5:
                    Console.WriteLine("5");
                    break;

                case 0:
                    Environment.Exit(0);
                    break;


                default:
                    Console.WriteLine("Def");
                    break;
             
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Must use a number to choose.");

        }
    }
}
