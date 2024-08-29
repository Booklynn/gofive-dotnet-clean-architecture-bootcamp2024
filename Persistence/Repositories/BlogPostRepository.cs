using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class BlogPostRepository(ApplicationDbContext dbContext) : IBlogPostRepository
{
    protected readonly ApplicationDbContext dbContext = dbContext;

    public async Task<int> CountBlogPosts()
    {
        return await dbContext.BlogPosts.AsNoTracking().CountAsync();
    }

    public async Task<BlogPost> CreateBlogPost(BlogPost blogPost)
    {
        await dbContext.BlogPosts.AddAsync(blogPost);
        await dbContext.SaveChangesAsync();
        
        return blogPost;
    }

    public async Task DeleteBlogPost(Guid id)
    {
        var existingBlogPost = await dbContext.BlogPosts.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        if (existingBlogPost == null)
        {
            return;
        }
        
        dbContext.BlogPosts.Remove(existingBlogPost);
        await dbContext.SaveChangesAsync();
        
        return;
    }

    public async Task<List<BlogPost>> GetAllBlogPosts()
    {
        return await dbContext.BlogPosts.AsNoTracking()
            .Include(x => x.Categories)
            .ToListAsync();
    }

    public async Task<BlogPost> GetBlogPostById(Guid id)
    {
        return await dbContext.BlogPosts.AsNoTracking()
            .Include(x => x.Categories)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<BlogPost> UpdateBlogPost(BlogPost blogPost)
    {
        var existingBlogPost = await dbContext.BlogPosts
            .Include(x => x.Categories)
            .FirstOrDefaultAsync(x => x.Id == blogPost.Id);

        if (existingBlogPost == null)
        {
            return null;
        }

        existingBlogPost.Categories.Clear();

        existingBlogPost.Title = blogPost.Title;
        existingBlogPost.ShortDescription = blogPost.ShortDescription;
        existingBlogPost.Content = blogPost.Content;
        existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
        existingBlogPost.UrlHandle = blogPost.UrlHandle;
        existingBlogPost.PublishedDate = blogPost.PublishedDate;
        existingBlogPost.Author = blogPost.Author;
        existingBlogPost.IsVisible = blogPost.IsVisible;
        existingBlogPost.Categories = blogPost.Categories;

        await dbContext.SaveChangesAsync();

        return existingBlogPost;
    }
}
