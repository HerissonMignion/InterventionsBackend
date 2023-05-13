using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InterventionsBackend.Models;
using InterventionsBackend.Filters;

namespace InterventionsBackend.Controllers;

[AddHeader("Access-Control-Allow-Origin", "*")]
[AddHeader("Access-Control-Allow-Headers", "*")]
[AddHeader("Access-Control-Allow-Methods", "*")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
