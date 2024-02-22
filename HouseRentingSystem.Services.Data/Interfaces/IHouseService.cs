namespace HouseRentingSystem.Services.Data.Interfaces;

using Web.ViewModels.Home;
using Web.ViewModels.House;

public interface IHouseService
{
    Task<IEnumerable<IndexViewModel>> LastThreeHosesAsync();
    Task CreateHouseAsync(HouseFormModel model, string agentId);
}
