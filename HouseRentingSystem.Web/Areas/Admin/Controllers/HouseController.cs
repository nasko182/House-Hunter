namespace HouseRentingSystem.Web.Areas.Admin.Controllers;

using Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using ViewModels.House;
using Web.ViewModels.House;

public class HouseController : BaseAdminController
{
    private readonly IAgentService _agentService;
    private readonly IHouseService _houseService;

    public HouseController(IAgentService agentService, IHouseService houseService)
    {
        this._agentService = agentService;
        this._houseService = houseService;
    }

    public async Task<IActionResult> Mine()
    {
        string? agentId = await this._agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);
        MyHousesViewModel viewModel = new MyHousesViewModel()
        {
            AddedHouses = await this._houseService.AllByAgentIdAsync(agentId!),
            RentedHouses = await this._houseService.AllByUserIdAsync(this.User.GetId()!)
        };

        return this.View(viewModel);
    }

    public async Task<IActionResult> AllRents()
    {
        IEnumerable<RentsViewModel> viewModel = await this._houseService.AllAsync();

        return this.View(viewModel);
    }
}
