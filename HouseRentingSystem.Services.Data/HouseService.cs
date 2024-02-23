namespace HouseRentingSystem.Services.Data;

using Microsoft.EntityFrameworkCore;

using Interfaces;
using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using Models.House;
using Web.ViewModels.Home;
using Web.ViewModels.House;
using Web.ViewModels.House.Enums;

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

    public async Task CreateHouseAsync(HouseFormModel model, string agentId)
    {
        await this._dbContext.Houses.AddAsync(new House
        {
            Title = model.Title,
            Address = model.Address,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            PricePerMonth = model.PricePerMonth,
            CategoryId = model.CategoryId,
            AgentId = Guid.Parse(agentId)
        });

        await this._dbContext.SaveChangesAsync();
    }

    public async Task<AllHousesFilteredAndPagedServiceModel> AllAsync(AllHousesQueryModel model)
    {
        IQueryable<House> housesQuery = this._dbContext
            .Houses
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(model.Category))
        {
            housesQuery = housesQuery
                .Where(h => h.Category.Name == model.Category);
        }

        if (!string.IsNullOrWhiteSpace(model.SearchString))
        {
            string wildCard = $"%{model.SearchString.ToLower()}%";

            housesQuery = housesQuery
                .Where(h => EF.Functions.Like(h.Title, wildCard) ||
                            EF.Functions.Like(h.Address, wildCard) ||
                            EF.Functions.Like(h.Description, wildCard));
        }

        housesQuery = model.HouseSorting switch
        {
            HouseSorting.Newest => housesQuery.OrderByDescending(h => h.CreatedOn),
            HouseSorting.Oldest => housesQuery.OrderBy(h => h.CreatedOn),
            HouseSorting.PriceAscending => housesQuery.OrderBy(h => h.PricePerMonth),
            HouseSorting.PriceDescending => housesQuery.OrderByDescending(h => h.PricePerMonth),
            _ => housesQuery.OrderBy(h => h.RenterId != null)
                .ThenByDescending(h => h.CreatedOn)
        };

        IEnumerable<HouseAllViewModel> houses = await housesQuery
            .Skip((model.CurrentPage - 1) * model.HousesPerPage)
            .Take(model.HousesPerPage)
            .Select(h => new HouseAllViewModel
            {
                Id = h.Id.ToString(),
                Title = h.Title,
                Address = h.Address,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                IsRented = h.RenterId != null
            })
            .ToArrayAsync();

        int totalHouses = housesQuery.Count();

        return new AllHousesFilteredAndPagedServiceModel
        {
            TotalHouseCount = totalHouses,
            Houses = houses
        };

    }
}
