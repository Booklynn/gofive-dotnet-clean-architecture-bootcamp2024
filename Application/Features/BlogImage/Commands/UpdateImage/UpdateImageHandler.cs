using Application.Contracts.Persistence;
using Application.Models.BlogImage;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Features.BlogImage.Commands.UpdateImage;

public class UpdateImageHandler(IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IMapper mapper, IBlogImageRepository blogImageRepository) : IRequestHandler<UpdateImageCommand, BlogImageDto>
{
    readonly IWebHostEnvironment hostingEnvironment = hostingEnvironment;
    readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;
    readonly IMapper mapper = mapper;
    readonly IBlogImageRepository blogImageRepository = blogImageRepository;
    
    public async Task<BlogImageDto> Handle(UpdateImageCommand command, CancellationToken cancellationToken)
    {
        var existingImage = await blogImageRepository.GetImageById(command.Id);
        if (existingImage == null)
        {
            return null;
        }

        var existingImageLocalPath = Path.Combine(hostingEnvironment.ContentRootPath, "Images", $"{existingImage.FileName}{existingImage.FileExtension}");
        if (File.Exists(existingImageLocalPath))
        {
            File.Delete(existingImageLocalPath);
        }

        var file = command.Request.File;
        var fileExtension = Path.GetExtension(file.FileName).ToLower();

        Directory.CreateDirectory(Path.Combine(hostingEnvironment.ContentRootPath, "Images"));

        var localPath = Path.Combine(hostingEnvironment.ContentRootPath, "Images", $"{command.Request.FileName}{fileExtension}");
        using var stream = new FileStream(localPath, FileMode.Create);
        await file.CopyToAsync(stream, cancellationToken);

        var httpRequest = httpContextAccessor.HttpContext.Request;
        var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{command.Request.FileName}{fileExtension}";

        var blogImageUpdateModel = mapper.Map<Domain.Entities.BlogImage>(command.Request);
        blogImageUpdateModel.Id = command.Id;
        blogImageUpdateModel.FileName = command.Request.FileName;
        blogImageUpdateModel.FileExtension = fileExtension;
        blogImageUpdateModel.Title = command.Request.Title;
        blogImageUpdateModel.Url = urlPath;
        blogImageUpdateModel.DateCreated = DateTime.Now;
        
        var result = await blogImageRepository.UpdateBlogImage(blogImageUpdateModel);

        return mapper.Map<BlogImageDto>(result);
    }
}
