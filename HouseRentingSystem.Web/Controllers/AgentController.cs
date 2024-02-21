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
        bool isAgent = await this._agentService.AgentExistByUserIdAsync(userId);
        if (isAgent)
        {
            this.TempData[ErrorMessage] = "You are already an agent";

            return this.RedirectToAction("Index", "Home");
        }

        bool isPhoneNumberTaken = await this._agentService.AgentExistByPhoneNumberAsync(model.PhoneNumber);
        if (isPhoneNumberTaken)
        {
            this.ModelState.AddModelError(nameof(model.PhoneNumber),"Agent with provided phone number already exists");
        }

        if (!this.ModelState.IsValid)
        {
            return this.View(model);
        }

        bool hasRents = await this._agentService.HasRentsByUserAsync(userId);
        if (hasRents)
        {
            this.TempData[ErrorMessage] = "You must not have any active rents in order to become an agent";

            return this.RedirectToAction("Mine", "House");
        }

        try
        {
            await this._agentService.CreateAsync(userId, model);
        }
        catch (Exception e)
        {
            this.TempData[ErrorMessage] =
                "Unexpected error occurred while registering you as new agent! Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }

        return this.RedirectToAction("All", "House");
    }
}
