using Application.Models.BlogPost;
using MediatR;

namespace Application.Features.BlogPost.Commands.UpdateBlogPost;

public class UpdateBlogPostCommand : IRequest<BlogPostDto>
{
    public Guid Id { get; set; }
    public UpdateBlogPostRequestDto Request { get; set; }
}
