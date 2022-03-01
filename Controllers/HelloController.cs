using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web_app.Models;

namespace web_app.Controllers;

public class HelloController : Controller
{
    private readonly ILogger<HelloController> _logger;

    public HelloController(ILogger<HelloController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return Content("<h1>Hello World</h1>", "text/html");
    }

    public IActionResult Goodbye()
    {
        return Content("Goodbye");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
