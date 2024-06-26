﻿namespace HouseRentingSystem.Services.Data;

using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.Agent;
using Web.ViewModels.User;

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

    public async Task<bool> HasHouseWithIdAsync(string userId, string houseId)
    {
        Agent? agent = await this._dbContext.Agents
            .Include(a => a.OwnedHouses)
            .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);

        if (agent == null)
        {
            return false;
        }

        return agent.OwnedHouses.Any(h => h.IsActive &&
                                          h.Id.ToString().ToLower() == houseId.ToLower());
    }

    public async Task<string> GetFullNameByIdAsync(string userId)
    {
        ApplicationUser? user = await this._dbContext
            .Users
            .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

        if (user == null)
        {
            return String.Empty;
        }

        return $"{user!.FirstName} {user.LastName}";
    }

    public async Task<IEnumerable<UserViewModel>> AllAsync()
    {
        List<UserViewModel> allUsers = await this._dbContext
            .Users
            .Select(u => new UserViewModel
            {
                Id = u.Id.ToString(),
                Email = u.Email,
                FullName = u.FirstName + " " + u.LastName
            })
            .ToListAsync();

        foreach (var user in allUsers)
        {
            Agent? agent = await this._dbContext
                .Agents
                .FirstOrDefaultAsync(a => a.UserId.ToString() == user.Id);

            if (agent != null)
            {
                user.PhoneNumber = agent.PhoneNumber;
            }
            else
            {
                user.PhoneNumber = String.Empty;
            }
        }

        return allUsers;
    }
}
