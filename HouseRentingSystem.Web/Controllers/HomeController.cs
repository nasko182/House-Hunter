﻿namespace HouseRentingSystem.Web.Controllers;

using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using ViewModels.Home;

public class HomeController : Controller
{
    private readonly IHouseService _houseService;

    public HomeController(IHouseService houseService)
    {
        _houseService = houseService;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<IndexViewModel> viewModel = await this._houseService.LastThreeHosesAsync();

        return View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
