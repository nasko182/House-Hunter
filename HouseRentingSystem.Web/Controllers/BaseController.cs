namespace HouseRentingSystem.Web.Controllers;

using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class BaseController : Controller
{
}
