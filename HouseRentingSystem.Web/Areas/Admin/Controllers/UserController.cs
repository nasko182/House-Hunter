namespace HouseRentingSystem.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using Web.ViewModels.User;

public class UserController : BaseAdminController
{
    private readonly IAgentService _agentService;

    public UserController(IAgentService agentService)
    {
        this._agentService = agentService;
    }
    public async Task<IActionResult> All()
    {
        IEnumerable<UserViewModel> viewModel =
            await this._agentService.AllAsync();

        return this.View(viewModel);
    }
}
