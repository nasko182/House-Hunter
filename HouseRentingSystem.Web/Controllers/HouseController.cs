namespace HouseRentingSystem.Web.Controllers;

using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using ViewModels.House;

using static Common.NotificationMessagesConstants;

public class HouseController : BaseController
{
    private readonly ICategoryService _categoryService;
    private readonly IAgentService _agentService;
    public HouseController(ICategoryService categoryService,IAgentService agentService)
    {
        this._categoryService = categoryService;
        this._agentService = agentService;
    }
    [AllowAnonymous] 
    public async Task<IActionResult> All()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        bool isAgent = await this._agentService.AgentExistByUserIdAsync(this.User.GetId()!);
        if (!isAgent)
        {
            this.TempData[ErrorMessage] = "You must become an agent in order to add new houses!";

            return this.RedirectToAction("Become", "Agent");
        }

        HouseFormModel formModel = new HouseFormModel()
        {
            Categories = await this._categoryService.AllCategoriesAsync()
        };

        return this.View(formModel);
    }
}
