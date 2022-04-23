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

    [HttpGet]
    public IActionResult Greeter()
    {
        return View();
    }

    [Route("/Hello/Greeter")]
    [HttpPost]
    public IActionResult GreeterDisplay(string name = "Your name", string language = "")
	{
        string message = CreateMessage(name, language);
        string html = "<h1>" + message + "</h1>";
        return Content(html, "text /html");
    }
    public static string CreateMessage(string name, string language)
    {
        string message = "";
        if (language == "English")
            {
                message = "Good day " + name;
            }
        if (language == "Spanish")
            {
                message = "Buenos dias " + name;
                //Using an i with an accent mark did not produce the proper result.
            }
        if (language == "German")
        {
            message = "Guten Tag " + name;
        }
        if (language == "French")
        {
            message = "Bonjour " + name;
        }
        if (language == "Italian")
        {
            message = "Buona giornata " + name;
        }
        return message;
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
