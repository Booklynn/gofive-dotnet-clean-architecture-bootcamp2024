using Application.Models.BlogImage;
using MediatR;

namespace Application.Features.BlogImage.Commands.UpdateImage;

public class UpdateImageCommand : IRequest<BlogImageDto>
{
    public Guid Id { get; set; }
    public UpdateImageRequestDto Request { get; set; }
}
