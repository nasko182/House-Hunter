namespace HouseRentingSystem.Services.Data;

using HouseRentingSystem.Data;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class AgentService : IAgentService
{
    private readonly HouseRentingDbContext _dbContext;

    public AgentService(HouseRentingDbContext dbContext)
    {
        this._dbContext = dbContext;
    }


    public async Task<bool> AgentExistByUserId(string userId)
    {
        return await this._dbContext
            .Agents
            .AnyAsync(a => a.UserId.ToString() == userId);
    }
}
