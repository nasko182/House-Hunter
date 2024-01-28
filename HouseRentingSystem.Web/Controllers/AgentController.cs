namespace HouseRentingSystem.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

public class AgentController : BaseController
{
    public async Task<IActionResult> Become()
    {
        return View();
    }
}
