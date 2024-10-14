using Resources.Models;

namespace Resources.Interface;

public interface IFileService
{
    public Response<string> GetFromFile();

    public Response<string> SaveToFile(string json);
}
