namespace HouseRentingSystem.Services.Data;

using HouseRentingSystem.Data;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.Category;

public class CategoryService : ICategoryService
{
    private readonly HouseRentingDbContext _dbContext;
    public CategoryService(HouseRentingDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoriesAsync()
    {
        return await this._dbContext.Categories
            .AsNoTracking()
            .Select(c => new HouseSelectCategoryFormModel
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToArrayAsync();
    }

    public Task<bool> ExistsByIdAsync(int categoryId)
    {
        return this._dbContext.Categories.AnyAsync(c => c.Id == categoryId);
    }
}
