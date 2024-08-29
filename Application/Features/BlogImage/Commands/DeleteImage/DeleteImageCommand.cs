using Application.Models.BlogImage;
using MediatR;

namespace Application.Features.BlogImage.Commands.DeleteImage;

public class DeleteImageCommand(Guid id) : IRequest<BlogImageDto>
{
    public Guid Id { get; set; } = id;
}
