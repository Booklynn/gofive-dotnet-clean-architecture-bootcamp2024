using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.BlogImage.Queries.CountImages;

public class CountImagesHandler(IBlogImageRepository blogImageRepository) : IRequestHandler<CountImagesQuery, int>
{
    readonly IBlogImageRepository blogImageRepository = blogImageRepository;
    public async Task<int> Handle(CountImagesQuery request, CancellationToken cancellationToken)
    {
        return await blogImageRepository.CountBlogImages();
    }
}
