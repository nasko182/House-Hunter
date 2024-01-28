namespace HouseRentingSystem.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


public class HouseController : BaseController
{
    [AllowAnonymous] 
    public async Task<IActionResult> All()
    {
        return View();
    }
}
