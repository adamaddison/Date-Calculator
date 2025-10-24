using Date_Calculator.Interfaces;
using Date_Calculator.Models.AddSubtract;
using Date_Calculator.View_Models.AddSubtract;
using Microsoft.AspNetCore.Mvc;

namespace Date_Calculator.Controllers;

[Route("AddSubtract")]
public class AddSubtractController : Controller
{
    private IAddSubtractService _service;
    
    public AddSubtractController(IAddSubtractService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Result()
    {
        var model = new AddSubtractRequest();

        var response = _service.CalculateNewDates(model);

        return View(response);
    }

    [HttpPost]
    [Route("")]
    public IActionResult Result(AddSubtractRequest request)
    {
        var errors = _service.ReturnModelErrors(request);
        if (errors.ErrorMessages.Any())
        {
            return View("Error", errors);
        }

        var response = _service.CalculateNewDates(request);

        return View(response);
    }

}
