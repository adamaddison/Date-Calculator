using Date_Calculator.Interfaces;
using Date_Calculator.Models.DateToDate;
using Date_Calculator.View_Models.DateToDate;
using Microsoft.AspNetCore.Mvc;

namespace Date_Calculator.Controllers;

[Route("")]
[Route("DateToDate")]
public class DateToDateController : Controller
{
    private IDateToDateService _service;

    public DateToDateController(IDateToDateService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Result()
    {
        var model = new DateToDateRequest();

        var response = _service.CalculateTimeSpan(model);

        return View(response);
    }

    [HttpPost]
    [Route("")]
    public IActionResult Result(DateToDateRequest request)
    {
        var errors = _service.ReturnModelErrors(request);
        if (errors.ErrorMessages.Any())
        {
            return View("Error", errors);
        }

        var response = _service.CalculateTimeSpan(request);
        
        return View(response);
    }
}