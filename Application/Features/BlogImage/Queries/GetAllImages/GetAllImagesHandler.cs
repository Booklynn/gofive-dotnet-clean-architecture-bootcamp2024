using Application.Contracts.Persistence;
using Application.Models.BlogImage;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogImage.Queries.GetAllImages;

public class GetAllImagesHandler(IBlogImageRepository blogImageRepository, IMapper mapper) : IRequestHandler<GetAllImagesQuery, List<BlogImageDto>>
{
    readonly IBlogImageRepository blogImageRepository = blogImageRepository;
    readonly IMapper mapper = mapper;


    public async Task<List<BlogImageDto>> Handle(GetAllImagesQuery request, CancellationToken cancellationToken)
    {
        var blogPosts = await blogImageRepository.GetAllBlogImages();
        return mapper.Map<List<BlogImageDto>>(blogPosts);
    }
}
