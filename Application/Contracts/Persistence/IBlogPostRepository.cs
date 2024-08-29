using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IBlogPostRepository
{
    Task<BlogPost> CreateBlogPost(BlogPost blogPost);
    Task<List<BlogPost>> GetAllBlogPosts();
    Task<BlogPost> GetBlogPostById(Guid id);
    Task<BlogPost> UpdateBlogPost(BlogPost blogPost);
    Task DeleteBlogPost(Guid id);
    Task<int> CountBlogPosts();
}
