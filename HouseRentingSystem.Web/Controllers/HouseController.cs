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
        string userId = this.User.GetId()!;
        try
        {
            IEnumerable<HouseAllViewModel> houses;
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
        catch (Exception e)
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred. Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }
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
        try
        {
            HouseFormModel formModel = new HouseFormModel()
            {
                Categories = await this._categoryService.AllCategoriesAsync()
            };

            return this.View(formModel);
        }
        catch (Exception e)
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred. Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }
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

        return this.RedirectToAction("Details", "House", new { id = model.});
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Details(string id)
    {

        bool houseExist = await this._houseService.ExistByIdAsync(id);
        if (!houseExist)
        {
            this.TempData[ErrorMessage] = "House with provided id does not exist!";

            return this.RedirectToAction("All", "House");
        }

        try
        {
            HouseDetailsViewModel model = await this._houseService.GetDetailsByHouseIdAsync(id);

            return this.View(model);
        }
        catch (Exception e)
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred. Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        bool houseExist = await this._houseService.ExistByIdAsync(id);
        if (!houseExist)
        {
            this.TempData[ErrorMessage] = "House with provided id does not exist!";

            return this.RedirectToAction("All", "House");
        }

        bool isAgent = await this._agentService.AgentExistByUserIdAsync(this.User.GetId()!);
        if (!isAgent)
        {
            this.TempData[ErrorMessage] = "You must become an agent in order to edit houses!";

            return this.RedirectToAction("Become", "Agent");
        }

        string? agentId = await this._agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);

        bool isOwner = await this._houseService.IsAgentWithIdOwnerOfHouseWithIdAsync(id, agentId!);

        if (!isOwner)
        {
            this.TempData[ErrorMessage] = "You must be the agent owner of the house!";

            this.RedirectToAction("Mine", "House");
        }

        try
        {
            HouseFormModel model = await this._houseService.GetHouseForEditByIdAsync(id);

            model.Categories = await this._categoryService.AllCategoriesAsync();

            return this.View(model);
        }
        catch (Exception e)
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred. Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }

    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, HouseFormModel model)
    {
        if (!this.ModelState.IsValid)
        {
            model.Categories = await this._categoryService.AllCategoriesAsync();
            return this.View(model);
        }

        bool houseExist = await this._houseService.ExistByIdAsync(id);
        if (!houseExist)
        {
            this.TempData[ErrorMessage] = "House with provided id does not exist!";

            return this.RedirectToAction("All", "House");
        }

        bool isAgent = await this._agentService.AgentExistByUserIdAsync(this.User.GetId()!);
        if (!isAgent)
        {
            this.TempData[ErrorMessage] = "You must become an agent in order to edit houses!";

            return this.RedirectToAction("Become", "Agent");
        }

        string? agentId = await this._agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);

        bool isOwner = await this._houseService.IsAgentWithIdOwnerOfHouseWithIdAsync(id, agentId!);

        if (!isOwner)
        {
            this.TempData[ErrorMessage] = "You must be the agent owner of the house!";

            this.RedirectToAction("Mine", "House");
        }


        try
        {
            await this._houseService.EditHouseByIdAndFormModel(id, model);
        }
        catch
        {
            this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to update the house. Please try again later or contact administrator.");

            model.Categories = await this._categoryService.AllCategoriesAsync();
            return this.View(model);
        }

        return this.RedirectToAction("Details", "House", new { id });
    }
}
