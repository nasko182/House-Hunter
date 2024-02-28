namespace HouseRentingSystem.Services.Data;

using Microsoft.EntityFrameworkCore;

using Interfaces;
using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using Models.House;
using Models.Statistics;
using Web.ViewModels.Agent;
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
            .Where(h => h.IsActive)
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

    public async Task<string> CreateHouseAsync(HouseFormModel model, string agentId)
    {
        House house = new House
        {
            Title = model.Title,
            Address = model.Address,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            PricePerMonth = model.PricePerMonth,
            CategoryId = model.CategoryId,
            AgentId = Guid.Parse(agentId)
        };

        await this._dbContext.Houses.AddAsync(house);
        await this._dbContext.SaveChangesAsync();

        return house.Id.ToString();
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
            .Where(h => h.IsActive)
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

    public async Task<IEnumerable<HouseAllViewModel>> AllByAgentIdAsync(string agentId)
    {
        return await this._dbContext
            .Houses
            .Where(h => h.IsActive)
            .Where(h => h.AgentId.ToString() == agentId)
            .Select(h => new HouseAllViewModel
            {
                Id = h.Id.ToString(),
                Title = h.Title,
                Address = h.Address,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                IsRented = h.RenterId.HasValue
            })
            .ToArrayAsync();
    }

    public async Task<IEnumerable<HouseAllViewModel>> AllByUserIdAsync(string userId)
    {
        return await this._dbContext
            .Houses
            .Where(h => h.IsActive &&
                        h.RenterId.HasValue &&
                        h.RenterId.ToString() == userId)
            .Select(h => new HouseAllViewModel
            {
                Id = h.Id.ToString(),
                Title = h.Title,
                Address = h.Address,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                IsRented = h.RenterId.HasValue
            })
            .ToArrayAsync();
    }

    public async Task<HouseDetailsViewModel> GetDetailsByHouseIdAsync(string houseId)
    {
        return await this._dbContext.Houses
            .Include(h => h.Category)
            .Include(h => h.Agent)
            .ThenInclude(a => a.User)
            .Where(h => h.IsActive &&
                        h.Id.ToString() == houseId)
            .Select(h => new HouseDetailsViewModel
            {
                Id = h.Id.ToString(),
                Title = h.Title,
                Address = h.Address,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                IsRented = h.RenterId.HasValue,
                Description = h.Description,
                Category = h.Category.Name,
                Agent = new AgentInfoOnHouseViewModel
                {
                    Email = h.Agent.User.Email,
                    PhoneNumber = h.Agent.PhoneNumber,
                }
            }).FirstAsync();
    }

    public async Task<bool> ExistByIdAsync(string houseId)
    {
        return await this._dbContext
            .Houses
            .Where(h => h.IsActive)
            .AnyAsync(h => h.Id.ToString() == houseId);
    }

    public async Task<HouseFormModel> GetHouseForEditByIdAsync(string houseId)
    {
        return await this._dbContext.Houses
            .Where(h => h.IsActive &&
                        h.Id.ToString() == houseId)
            .Select(h => new HouseFormModel()
            {
                Title = h.Title,
                Address = h.Address,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                Description = h.Description,
                CategoryId = h.CategoryId
            }).FirstAsync();
    }

    public async Task EditHouseByIdAndFormModelAsync(string houseId, HouseFormModel model)
    {
        House house = await this._dbContext.Houses
            .Where(h => h.IsActive)
            .FirstAsync(h => h.Id.ToString() == houseId);

        house.Title = model.Title;
        house.Address = model.Address;
        house.Description = model.Description;
        house.ImageUrl = model.ImageUrl;
        house.PricePerMonth = model.PricePerMonth;
        house.CategoryId = model.CategoryId;

        await this._dbContext.SaveChangesAsync();
    }

    public async Task<DeleteHouseFormModel> GetHouseForDeleteAsync(string houseId)
    {
        return await this._dbContext.Houses
            .Where(h => h.IsActive &&
                        h.Id.ToString() == houseId)
            .Select(h => new DeleteHouseFormModel
            {
                Title = h.Title,
                Address = h.Address,
                ImageUrl = h.ImageUrl
            })
            .FirstAsync();
    }

    public async Task DeleteByIdAsync(string houseId)
    {
        House house = await this._dbContext
            .Houses
            .Where(h => h.IsActive)
            .FirstAsync(h => h.Id.ToString() == houseId);

        house.IsActive = false;

        await this._dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsRentedAsync(string houseId)
    {
        House house = await this._dbContext
            .Houses
            .Where(h => h.IsActive)
            .FirstAsync(h => h.Id.ToString() == houseId);

        return house.RenterId.HasValue;
    }

    public async Task<bool> IsRentedByUserAsync(string houseId, string userId)
    {
        House house = await this._dbContext
            .Houses
            .Where(h => h.IsActive)
            .FirstAsync(h => h.Id.ToString() == houseId);

        return house.RenterId.ToString() == userId;
    }

    public async Task RentAsync(string houseId, string userId)
    {
        House house = await this._dbContext
            .Houses
            .Where(h => h.IsActive)
            .FirstAsync(h => h.Id.ToString() == houseId);

        house.RenterId = Guid.Parse(userId);

        await this._dbContext.SaveChangesAsync();
    }

    public async Task LeaveAsync(string houseId, string userId)
    {
        House house = await this._dbContext
            .Houses
            .Where(h => h.IsActive)
            .FirstAsync(h => h.Id.ToString() == houseId &&
                             h.RenterId.ToString() == userId);

        house.RenterId = null;

        await this._dbContext.SaveChangesAsync();
    }

    public async Task<StatisticsServiceModel> GetStatisticsAsync()
    {
        return new StatisticsServiceModel
        {
            TotalHouses = await this._dbContext.Houses.CountAsync(),
            TotalRents = await this._dbContext.Houses
                .Where(h => h.RenterId.HasValue)
                .CountAsync()
        };
    }

    public async Task<bool> IsAgentWithIdOwnerOfHouseWithIdAsync(string houseId, string agentId)
    {
        House house = await this._dbContext.Houses
            .Where(h => h.IsActive)
            .FirstAsync(h => h.Id.ToString() == houseId);

        return house.AgentId.ToString() == agentId;
    }
}
