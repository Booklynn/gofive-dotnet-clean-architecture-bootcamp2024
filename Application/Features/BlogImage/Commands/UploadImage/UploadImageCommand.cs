using Application.Models.BlogImage;
using MediatR;

namespace Application.Features.BlogImage.Commands.UploadImage;

public class UploadImageCommand : IRequest<BlogImageDto>
{
    public UploadImageRequestDto Request { get; set; }
}
