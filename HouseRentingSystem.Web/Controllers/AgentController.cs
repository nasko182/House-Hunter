namespace HouseRentingSystem.Web.Controllers;

using Microsoft.AspNetCore.Mvc;

using Services.Data.Interfaces;
using Infrastructure.Extensions;

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
        bool isAgent = await this._agentService.AgentExistByUserId(userId!);

        if (isAgent)
        {
            return this.BadRequest();
        }
        return this.View();
    }
}
