using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class CategoryRepository(ApplicationDbContext dbContext) : ICategoryRepository {
        protected readonly ApplicationDbContext dbContext = dbContext;

        public Task<int> CountCategories()
        {
            return dbContext.Categories.AsNoTracking().CountAsync();
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            
            return category;
        }

        public async Task DeleteCategory(Guid id)
        {
            var existingCategory = await dbContext.Categories.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (existingCategory == null)
            {
                return;
            }
            
            dbContext.Categories.Remove(existingCategory);
            await dbContext.SaveChangesAsync();
            
            return;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await dbContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id) {
            return await dbContext.Categories.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var existingCategory = await dbContext.Categories.Where(x => x.Id == category.Id).FirstOrDefaultAsync();
            if (existingCategory == null)
            {
                return null;
            }
            
            existingCategory.Name = category.Name;
            existingCategory.UrlHandle = category.UrlHandle;
            await dbContext.SaveChangesAsync();
            
            return existingCategory;
        }
    }
}
