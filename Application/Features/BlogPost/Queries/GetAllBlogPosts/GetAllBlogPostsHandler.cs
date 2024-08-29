using Application.Contracts.Persistence;
using Application.Models.BlogPost;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetAllBlogPosts;

public class GetAllBlogPostsHandler(IBlogPostRepository blogPostRepository, IMapper mapper) : IRequestHandler<GetAllBlogPostsQuery, List<BlogPostDto>>
{
    readonly IBlogPostRepository blogPostRepository = blogPostRepository;
    readonly IMapper mapper = mapper;

    public async Task<List<BlogPostDto>> Handle(GetAllBlogPostsQuery request, CancellationToken cancellationToken)
    {
        var blogPosts = await blogPostRepository.GetAllBlogPosts();
        return mapper.Map<List<BlogPostDto>>(blogPosts);
    }
}
