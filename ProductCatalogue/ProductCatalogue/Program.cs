using ProductCatalogue.Menues;
using ProductCatalogue.Services;


while (true)
{
    //Start the mainmenu part and goes from there.
    MainMenu.DisplayMenu();
    Console.ReadKey();


    //Making sure the filepath works.
    string donk = FileService.JsonService();
    Console.WriteLine(donk);

}
