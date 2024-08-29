using Application.Contracts.Persistence;
using Application.Models.BlogPost;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Commands.CreateBlogPost;

public class CreatePostHandler(
    IBlogPostRepository blogPostRepository, 
    IMapper mapper,
    ICategoryRepository categoryRepository) : IRequestHandler<CreateBlogPostCommand, BlogPostDto>
{
    readonly IBlogPostRepository blogPostRepository = blogPostRepository;
    readonly IMapper mapper = mapper;
    readonly ICategoryRepository categoryRepository = categoryRepository;

    public async Task<BlogPostDto> Handle(CreateBlogPostCommand command, CancellationToken cancellationToken)
    {
        var blogPost = mapper.Map<Domain.Entities.BlogPost>(command.Request);

        foreach (var id in command.Request.Categories)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category is not null)
            {
                blogPost.Categories.Add(category);
            }
        }

        var result = await blogPostRepository.CreateBlogPost(blogPost);
        return mapper.Map<BlogPostDto>(result);
    }
}
