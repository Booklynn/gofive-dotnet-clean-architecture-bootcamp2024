using Application.Models.BlogImage;
using MediatR;

namespace Application.Features.BlogImage.Queries.GetImageById;

public class GetImageByIdQuery(Guid id) : IRequest<BlogImageDto>
{
    public Guid Id { get; set; } = id;
}

