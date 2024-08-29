using Application.Contracts.Persistence;
using Application.Models.BlogPost;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPostById;

public class GetBlogPostByIdHandler(IBlogPostRepository blogPostRepository, IMapper mapper) : IRequestHandler<GetBlogPostByIdQuery, BlogPostDto>
{
    readonly IBlogPostRepository blogPostRepository = blogPostRepository;
    readonly IMapper mapper = mapper;

    public async Task<BlogPostDto> Handle(GetBlogPostByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await blogPostRepository.GetBlogPostById(request.Id);
        return mapper.Map<BlogPostDto>(category);
    }
}
