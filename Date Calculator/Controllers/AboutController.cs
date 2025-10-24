using Microsoft.AspNetCore.Mvc;

namespace Date_Calculator.Controllers;

[Route("About")]
public class AboutController : Controller
{
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

}