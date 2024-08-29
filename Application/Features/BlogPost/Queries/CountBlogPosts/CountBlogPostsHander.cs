using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.BlogPost.Queries.CountBlogPosts;

public class CountBlogPostsHander(IBlogPostRepository blogPostRepository) : IRequestHandler<CountBlogPostsQuery, int>
{
    readonly IBlogPostRepository blogPostRepository = blogPostRepository;

    public async Task<int> Handle(CountBlogPostsQuery request, CancellationToken cancellationToken)
    {
        return await blogPostRepository.CountBlogPosts();
    }
}
