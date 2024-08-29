using Application.Models.BlogPost;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPostById;

public class GetBlogPostByIdQuery(Guid id) : IRequest<BlogPostDto>
{
    public Guid Id { get; set; } = id;
}
