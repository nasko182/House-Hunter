namespace HouseRentingSystem.Web.WebAPI.Controllers;

using System.Net;
using Microsoft.AspNetCore.Mvc;

using Services.Data.Interfaces;
using Services.Data.Models.Statistics;

[Route("api/statistics")]
[ApiController]
public class StatisticsApiController : ControllerBase
{
    private readonly IHouseService _houseService;

    public StatisticsApiController(IHouseService houseService)
    {
        this._houseService = houseService;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(StatisticsServiceModel))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetStatistics()
    {
        try
        {
            StatisticsServiceModel model = await this._houseService.GetStatisticsAsync();

            return this.Ok(model);
        }
        catch
        {
            return this.BadRequest();
        }
    }
}
