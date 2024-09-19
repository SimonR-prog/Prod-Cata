
namespace ProductCatalogue.Models;

public class ResponseResult
{
    public bool Succeeded { get; set; }
    public object? Content { get; set; } = null!;
    public string? Message { get; set; } = null!;
}

