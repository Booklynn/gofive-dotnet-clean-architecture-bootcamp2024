using Microsoft.AspNetCore.Http;

namespace Application.Models.BlogImage;

public class UpdateImageRequestDto
{
    public IFormFile File { get; set; }
    public string FileName { get; set; }
    public string Title { get; set; }
}
