namespace HouseRentingSystem.Services.Data.Interfaces;

using Models.House;

using Web.ViewModels.Home;
using Web.ViewModels.House;

public interface IHouseService
{
    Task<IEnumerable<IndexViewModel>> LastThreeHosesAsync();
    Task CreateHouseAsync(HouseFormModel model, string agentId);

    Task<AllHousesFilteredAndPagedServiceModel> AllAsync(AllHousesQueryModel model);
}
