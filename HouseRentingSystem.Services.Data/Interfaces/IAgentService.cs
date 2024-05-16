namespace HouseRentingSystem.Services.Data.Interfaces;

using Web.ViewModels.Agent;
using Web.ViewModels.User;

public interface IAgentService
{
    Task<bool> AgentExistByUserIdAsync(string userId);
    Task<bool> AgentExistByPhoneNumberAsync(string phoneNumber);
    Task<bool> HasRentsByUserAsync(string userId);
    Task CreateAsync(string userId, BecomeAgentFormModel model);
    Task<string?> GetAgentIdByUserIdAsync(string userId);
    Task<bool> HasHouseWithIdAsync(string userId, string houseId);
    Task<string> GetFullNameByIdAsync(string userId);
    Task<IEnumerable<UserViewModel>> AllAsync();
}
