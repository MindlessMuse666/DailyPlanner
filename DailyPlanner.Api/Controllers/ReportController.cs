using Microsoft.AspNetCore.Mvc;

namespace DailyPlanner.Api.Controllers;

public class ReportController : ControllerBase
{
    public IActionResult Index()
    {
        return View();
    }
}