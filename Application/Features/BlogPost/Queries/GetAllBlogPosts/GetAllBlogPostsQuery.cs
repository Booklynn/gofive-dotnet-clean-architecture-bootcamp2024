using Application.Models.BlogPost;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetAllBlogPosts;

public class GetAllBlogPostsQuery : IRequest<List<BlogPostDto>>
{

}
