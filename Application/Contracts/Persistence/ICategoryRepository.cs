using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface ICategoryRepository {
        Task<Category> GetByIdAsync(Guid id);
        Task<List<Category>> GetAllCategories();
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(Guid id);
        Task<int> CountCategories();
    }
}
