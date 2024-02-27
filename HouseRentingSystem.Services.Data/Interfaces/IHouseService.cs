namespace HouseRentingSystem.Services.Data.Interfaces;

using Models.House;

using Web.ViewModels.Home;
using Web.ViewModels.House;

public interface IHouseService
{
    Task<IEnumerable<IndexViewModel>> LastThreeHosesAsync();
    Task CreateHouseAsync(HouseFormModel model, string agentId);
    Task<AllHousesFilteredAndPagedServiceModel> AllAsync(AllHousesQueryModel model);
    Task<IEnumerable<HouseAllViewModel>> AllByAgentIdAsync(string agentId);
    Task<IEnumerable<HouseAllViewModel>> AllByUserIdAsync(string userId);
    Task<HouseDetailsViewModel> GetDetailsByHouseIdAsync(string houseId);
    Task<bool> ExistByIdAsync(string houseId);
    Task<HouseFormModel> GetHouseForEditByIdAsync(string houseId);
    Task DeleteByIdAsync(string houseId);
}
