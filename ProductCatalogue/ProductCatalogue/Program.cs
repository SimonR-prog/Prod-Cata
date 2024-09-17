using ProductCatalogue.Menues;
using ProductCatalogue.Services;


int dink = 1;
while (dink < 4)
{
    //Start the mainmenu part and goes from there.
    MainMenu.DisplayMenu();
    Console.ReadKey();



    string donk = FileService.JsonService();
    Console.WriteLine(donk);


    dink++;
}
