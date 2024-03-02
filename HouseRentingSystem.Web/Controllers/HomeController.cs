namespace HouseRentingSystem.Web.Controllers;

using Microsoft.AspNetCore.Mvc;

using Infrastructure.Extensions;
using Services.Data.Interfaces;
using ViewModels.Home;

using static Common.GeneralApplicationConstants;

public class HomeController : Controller
{
    private readonly IHouseService _houseService;

    public HomeController(IHouseService houseService)
    {
        this._houseService = houseService;
    }

    public async Task<IActionResult> Index()
    {
        if (this.User.IsAdmin())
        {
            return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
        }
        IEnumerable<IndexViewModel> viewModel = await this._houseService.LastThreeHosesAsync();

        return this.View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int statusCode)
    {
        if (statusCode == 400 || statusCode == 404)
        {
            return this.View("Error404");
        }
        return this.View();
    }
}
