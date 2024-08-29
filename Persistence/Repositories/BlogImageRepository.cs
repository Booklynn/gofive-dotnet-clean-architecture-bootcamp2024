using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class BlogImageRepository(ApplicationDbContext dbContext) : IBlogImageRepository
{
    protected readonly ApplicationDbContext dbContext = dbContext;

    public async Task<int> CountBlogImages()
    {
        return await dbContext.BlogImages.AsNoTracking().CountAsync();
    }

    public async Task DeleteImage(Guid id)
    {
        var existingImage = dbContext.BlogImages.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (existingImage == null)
        {
            return;
        }

        dbContext.BlogImages.Remove(existingImage);
        await dbContext.SaveChangesAsync();
        
        return;
    }

    public async Task<List<BlogImage>> GetAllBlogImages()
    {
        return await dbContext.BlogImages.AsNoTracking().ToListAsync();
    }

    public async Task<BlogImage> GetImageById(Guid id)
    {
        return await dbContext.BlogImages.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<BlogImage> SaveImage(BlogImage blogImage)
    {
        await dbContext.BlogImages.AddAsync(blogImage);
        await dbContext.SaveChangesAsync();

        return blogImage;
    }

    public async Task<BlogImage> UpdateBlogImage(BlogImage blogImage)
    {
        var existingImage = dbContext.BlogImages.AsNoTracking().FirstOrDefault(x => x.Id == blogImage.Id);
        if (existingImage == null)
        {
            return null;
        }

        dbContext.BlogImages.Update(blogImage);
        await dbContext.SaveChangesAsync();

        return blogImage;
    }
}
