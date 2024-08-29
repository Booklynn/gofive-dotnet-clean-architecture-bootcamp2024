using Application.Contracts.Persistence;
using Application.Models.BlogPost;
using MediatR;

namespace Application.Features.BlogPost.Commands.DeleteBlogPost;

public class DeleteBlogPostHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<DeleteBlogPostCommand, BlogPostDto>
{
    readonly IBlogPostRepository blogPostRepository = blogPostRepository;

    public async Task<BlogPostDto> Handle(DeleteBlogPostCommand command, CancellationToken cancellationToken)
    {
        await blogPostRepository.DeleteBlogPost(command.Id);
        return null;
    }
}
