using Application.Models.BlogImage;
using MediatR;

namespace Application.Features.BlogImage.Queries.GetAllImages;

public class GetAllImagesQuery : IRequest<List<BlogImageDto>>
{
}
