namespace HouseRentingSystem.Services.Data;

using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.Agent;

public class AgentService : IAgentService
{
    private readonly HouseRentingDbContext _dbContext;

    public AgentService(HouseRentingDbContext dbContext)
    {
        this._dbContext = dbContext;
    }


    public async Task<bool> AgentExistByUserIdAsync(string userId)
    {
        return await this._dbContext
            .Agents
            .AnyAsync(a => a.UserId.ToString() == userId);
    }

    public async Task<bool> AgentExistByPhoneNumberAsync(string phoneNumber)
    {
        return await this._dbContext
            .Agents
            .AnyAsync(a => a.PhoneNumber == phoneNumber);

    }

    public async Task<bool> HasRentsByUserAsync(string userId)
    {
        ApplicationUser? user = await this._dbContext
            .Users
            .FirstOrDefaultAsync(u => u.Id.ToString() == userId);
        if (user == null)
        {
            return false;
        }

        return user.RentedHouses.Any();
    }

    public async Task CreateAsync(string userId, BecomeAgentFormModel model)
    {
        Agent agent = new Agent
        {
            PhoneNumber = model.PhoneNumber,
            UserId = Guid.Parse(userId)
        };

        await this._dbContext.Agents.AddAsync(agent);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task<string?> GetAgentIdByUserIdAsync(string userId)
    {
        Agent? agent = await this._dbContext
            .Agents
            .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);

        if (agent == null)
        {
            return null;
        }

        return agent.Id.ToString();
    }
}
