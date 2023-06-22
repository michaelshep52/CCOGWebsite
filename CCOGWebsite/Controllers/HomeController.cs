using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CCOGWebsite.Models;

namespace CCOGWebsite.Controllers;

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
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Giving()
    {
        return  View();
    }
    public IActionResult Ministry()
    {
        return View();
    }
    public IActionResult MinistryForm()
    {
        return View();
    }

    public IActionResult OnlineServices()
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

