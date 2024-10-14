using Resources.Interface;
using Resources.Models;

namespace Resources.Services;

public class FileService(string filePath) : IFileService
{

    //Maybe need to make it so that the writer can only write to the intended file and that the reader can read from two different files.
    //Need to make it so that if the user doesn't provide a string with the filepath then the method uses a default filepath.

    /*
     public FileService(string filePath)
    {
        _filePath = filePath;
    }
     
     //Probably need this to set different strings as the filepath to where to get the lists from to merge them?
     */

    private readonly string _filePath = filePath;
    public Response<string> GetFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException("File not found");

            using var sr = new StreamReader(_filePath);
            var content = sr.ReadToEnd();

            return new Response<string> 
            { 
                Succeeded = true, 
                Content = content
            };
        }
        catch (Exception ex)
        {
            return new Response<string> 
            { 
                Succeeded = false, 
                Message = ex.Message 
            };
        }
    }

    public Response<string> SaveToFile(string content)
    {
        try
        {
            using var sw = new StreamWriter(_filePath, false);
            sw.WriteLine(content);

            return new Response<string> 
            { 
                Succeeded = true 
            };
        }
        catch (Exception ex)
        {
            return new Response<string> 
            { 
                Succeeded = false, 
                Message = ex.Message 
            };
        }
    }
}
