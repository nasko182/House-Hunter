namespace HouseRentingSystem.Services.Data;

using Microsoft.EntityFrameworkCore;

using Interfaces;
using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using Web.ViewModels.Home;
using Web.ViewModels.House;

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

    public async Task CreateHouseAsync(HouseFormModel model,string agentId)
    {
        await this._dbContext.Houses.AddAsync(new House
        {
            Title = model.Title,
            Address = model.Address,
            Description = model.Address,
            ImageUrl = model.ImageUrl,
            PricePerMonth = model.PricePerMonth,
            CategoryId = model.CategoryId,
            AgentId = Guid.Parse(agentId)
        });

        await this._dbContext.SaveChangesAsync();
    }
}
