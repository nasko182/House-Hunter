namespace HouseRentingSystem.Web.Controllers;

using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using Services.Data.Models.House;
using ViewModels.House;

using static Common.NotificationMessagesConstants;

public class HouseController : BaseController
{
    private readonly ICategoryService _categoryService;
    private readonly IAgentService _agentService;
    private readonly IHouseService _houseService;

    public HouseController(ICategoryService categoryService, IAgentService agentService, IHouseService houseService)
    {
        this._categoryService = categoryService;
        this._agentService = agentService;
        this._houseService = houseService;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> All([FromQuery] AllHousesQueryModel model)
    {
        AllHousesFilteredAndPagedServiceModel serviceModel = await this._houseService.AllAsync(model);

        model.Houses = serviceModel.Houses;
        model.TotalHouses = serviceModel.TotalHouseCount;
        model.Categories = await this._categoryService.GetAllCategoryNamesAsync();

        return this.View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        IEnumerable<HouseAllViewModel> houses;

        string userId = this.User.GetId()!;

        if (await this._agentService.AgentExistByUserIdAsync(userId))
        {
            string? agentId = await this._agentService.GetAgentIdByUserIdAsync(userId);

            houses = await this._houseService.AllByAgentIdAsync(agentId!);
        }
        else
        {
            houses = await this._houseService.AllByUserIdAsync(userId);
        }

        return this.View(houses);
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

    [HttpPost]
    public async Task<IActionResult> Add(HouseFormModel model)
    {
        bool isAgent = await this._agentService.AgentExistByUserIdAsync(this.User.GetId()!);
        if (!isAgent)
        {
            this.TempData[ErrorMessage] = "You must become an agent in order to add new houses!";

            return this.RedirectToAction("Become", "Agent");
        }

        bool isCategoryExist = await this._categoryService.ExistsByIdAsync(model.CategoryId);
        if (!isCategoryExist)
        {
            this.ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist.");
        }

        if (!this.ModelState.IsValid)
        {
            model.Categories = await this._categoryService.AllCategoriesAsync();

            return this.View(model);
        }

        try
        {
            string? agentId = await this._agentService
                .GetAgentIdByUserIdAsync(this.User.GetId()!);

            await this._houseService.CreateHouseAsync(model, agentId!);
        }
        catch
        {
            this.ModelState.AddModelError(String.Empty,
                "Unexpected error occurred while trying to add your new house! Please try again later or contact administrator.");

            model.Categories = await this._categoryService.AllCategoriesAsync();
            return this.View(model);
        }

        return this.RedirectToAction("All", "House");
    }
}
