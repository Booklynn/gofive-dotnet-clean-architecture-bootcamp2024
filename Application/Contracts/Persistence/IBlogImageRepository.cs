using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IBlogImageRepository
{
    Task<BlogImage> GetImageById(Guid id);
    Task<BlogImage> SaveImage(BlogImage blogImage);
    Task DeleteImage(Guid id);
    Task<List<BlogImage>> GetAllBlogImages();
    Task<int> CountBlogImages();
    Task<BlogImage> UpdateBlogImage(BlogImage blogImage);
}
