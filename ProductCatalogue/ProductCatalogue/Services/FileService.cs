using ProductCatalogue.Models;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace ProductCatalogue.Services;

public class FileService
{
    internal static string? _file;

    internal static string JsonService()
    {
        _file = "C:\\Nackademin\\c#\\Git\\Prod-Cata\\ProductCatalogue\\ProductCatalogue\\Text Files\\productlist.json";
        return _file;
    }
}

/*


//Method to write to the txt.file in json.
public bool ExportJson(List<Product> productList)
{
    string jsonString = JsonSerializer.Serialize(productList);
    File.WriteAllText("C:\\Nackademin\\c#\\Git\\Prod-Cata\\ProductCatalogue\\ProductCatalogue\\Text Files\\productlist.json", jsonString);
    return true;
}

//Method to read from the txt.file and put it into a list.
public List<String> ImportJson()
{
    List<Product> productList = new List<Product>;

    string jsonString = File.ReadAllText("C:\\Nackademin\\c#\\Git\\Prod-Cata\\ProductCatalogue\\ProductCatalogue\\Text Files\\productlist.json");
    List<Product> productList = JsonSerializer.Deserialize<List<Product>>(jsonString);

    return List<Product> productList;
}




}


*/