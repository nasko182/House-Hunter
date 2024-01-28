namespace HouseRentingSystem.Services.Data.Interfaces;

using Web.ViewModels.Home;

public interface IHouseService
{
    Task<IEnumerable<IndexViewModel>> LastThreeHosesAsync();
}
