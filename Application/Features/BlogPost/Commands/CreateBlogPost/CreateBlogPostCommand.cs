using Application.Models.BlogPost;
using MediatR;

namespace Application.Features.BlogPost.Commands.CreateBlogPost;

public class CreateBlogPostCommand : IRequest<BlogPostDto>
{
    public CreateBlogPostRequestDto Request { get; set; }
}
