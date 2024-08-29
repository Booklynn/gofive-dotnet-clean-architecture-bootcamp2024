using Application.Contracts.Persistence;
using Application.Models.BlogImage;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Application.Features.BlogImage.Commands.DeleteImage;

public class DeleteImageHandler(IBlogImageRepository blogImageRepository, IWebHostEnvironment hostingEnvironment) : IRequestHandler<DeleteImageCommand, BlogImageDto>
{
    readonly IBlogImageRepository blogImageRepository = blogImageRepository;
    readonly IWebHostEnvironment hostingEnvironment = hostingEnvironment;

    public async Task<BlogImageDto> Handle(DeleteImageCommand command, CancellationToken cancellationToken)
    {
        var existingImage = await blogImageRepository.GetImageById(command.Id);
        if (existingImage == null)
        {
            return null;
        }
        
        var localPath = Path.Combine(hostingEnvironment.ContentRootPath, "Images", $"{existingImage.FileName}{existingImage.FileExtension}");
        if (File.Exists(localPath))
        {
            File.Delete(localPath);
        }
        
        await blogImageRepository.DeleteImage(command.Id);
        return null;
    }
}
