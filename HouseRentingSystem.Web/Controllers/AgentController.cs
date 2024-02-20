namespace HouseRentingSystem.Web.Controllers;

using Microsoft.AspNetCore.Mvc;

using Services.Data.Interfaces;
using Infrastructure.Extensions;
using ViewModels.Agent;
using static Common.NotificationMessagesConstants;

public class AgentController : BaseController
{
    private readonly IAgentService _agentService;

    public AgentController(IAgentService agentService)
    {
        this._agentService = agentService;
    }

    [HttpGet]
    public async Task<IActionResult> Become()
    {
        string? userId = this.User.GetId();
        bool isAgent = await this._agentService.AgentExistByUserIdAsync(userId!);

        if (isAgent)
        {
            TempData[ErrorMessage] = "You are already an agent";
            return this.RedirectToAction("Index", "Home");
        }

        return this.View();
    }

    [HttpPost]
    public async Task<IActionResult> Become(BecomeAgentFormModel model)
    {
        string? userId = this.User.GetId();
        bool isAgent = await this._agentService.AgentExistByUserIdAsync(userId)
    }
}
