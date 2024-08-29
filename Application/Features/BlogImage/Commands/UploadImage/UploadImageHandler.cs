using Application.Contracts.Persistence;
using Application.Models.BlogImage;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Features.BlogImage.Commands.UploadImage;

public class UploadBlogImageHandler(IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IMapper mapper, IBlogImageRepository blogImageRepository) : IRequestHandler<UploadImageCommand, BlogImageDto>
{
    readonly IWebHostEnvironment hostingEnvironment = hostingEnvironment;
    readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;
    readonly IMapper mapper = mapper;
    readonly IBlogImageRepository IBlogImageRepository = blogImageRepository;
    
    public async Task<BlogImageDto> Handle(UploadImageCommand command, CancellationToken cancellationToken)
    {
        var file = command.Request.File;
        var fileExtension = Path.GetExtension(file.FileName).ToLower();

        Directory.CreateDirectory(Path.Combine(hostingEnvironment.ContentRootPath, "Images"));

        var localPath = Path.Combine(hostingEnvironment.ContentRootPath, "Images", $"{command.Request.FileName}{fileExtension}");
        using var stream = new FileStream(localPath, FileMode.Create);
        await file.CopyToAsync(stream, cancellationToken);

        var httpRequest = httpContextAccessor.HttpContext.Request;
        var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{command.Request.FileName}{fileExtension}";

        var blogImage = new Domain.Entities.BlogImage {
            FileName = command.Request.FileName,
            Title = command.Request.Title,
            FileExtension = fileExtension,
            Url = urlPath,
            DateCreated = DateTime.Now
        };

        var result = await IBlogImageRepository.SaveImage(blogImage);

        return mapper.Map<BlogImageDto>(result);
    }
}
