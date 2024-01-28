namespace HouseRentingSystem.Services.Data;

using Microsoft.EntityFrameworkCore;

using Interfaces;
using HouseRentingSystem.Data;
using Web.ViewModels.Home;

public class HouseService : IHouseService
{
    private readonly HouseRentingDbContext _dbContext;

    public HouseService(HouseRentingDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<IEnumerable<IndexViewModel>> LastThreeHosesAsync()
    {
        IEnumerable<IndexViewModel> lastThreeHouses = await this._dbContext
            .Houses
            .OrderByDescending(h => h.CreatedOn)
            .Take(3)
            .Select(h => new IndexViewModel
            {
                Id = h.Id.ToString(),
                Title = h.Title,
                ImageUrl = h.ImageUrl
            })
            .ToArrayAsync();

        return lastThreeHouses;
    }
}
