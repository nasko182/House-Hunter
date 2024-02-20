namespace HouseRentingSystem.Services.Data.Interfaces;

using Web.ViewModels.Agent;

public interface IAgentService
{
    Task<bool> AgentExistByUserIdAsync(string userId);
    Task<bool> AgentExistByPhoneNumberAsync(string phoneNumber);
    Task<bool> HasRentsByUserAsync(string userId);
    Task CreateAsync (string userId, BecomeAgentFormModel model);


}
