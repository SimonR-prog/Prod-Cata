namespace Resources.Interface;

public interface IFileService
{
    public string ReadFromJson();

    public string WriteToJson(string json);
}
