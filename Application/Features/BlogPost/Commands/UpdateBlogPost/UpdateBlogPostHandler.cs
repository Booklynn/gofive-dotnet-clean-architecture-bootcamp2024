using Application.Contracts.Persistence;
using Application.Models.BlogPost;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Commands.UpdateBlogPost;

public class UpdateBlogPostHandler(IBlogPostRepository blogPostRepository, IMapper mapper, ICategoryRepository categoryRepository) : IRequestHandler<UpdateBlogPostCommand, BlogPostDto>
{
    readonly IBlogPostRepository blogPostRepository = blogPostRepository;
    readonly IMapper mapper = mapper;
    readonly ICategoryRepository categoryRepository = categoryRepository;

    public async Task<BlogPostDto> Handle(UpdateBlogPostCommand command, CancellationToken cancellationToken)
    {
        var updateBlogPostModel = mapper.Map<Domain.Entities.BlogPost>(command.Request);
        updateBlogPostModel.Id = command.Id;

        foreach (var id in command.Request.Categories)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category is not null)
            {
                updateBlogPostModel.Categories.Add(category);
            }
        }

        var result = await blogPostRepository.UpdateBlogPost(updateBlogPostModel);
        return mapper.Map<BlogPostDto>(result);
    }
}
