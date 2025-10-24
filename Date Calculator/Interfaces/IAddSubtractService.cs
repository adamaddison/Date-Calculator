using System;
using Date_Calculator.Models.AddSubtract;
using Date_Calculator.View_Models.AddSubtract;

namespace Date_Calculator.Interfaces;

public interface IAddSubtractService
{
    public AddSubtractResultViewModel CalculateNewDates(AddSubtractRequest model);
    public AddSubtractErrorViewModel ReturnModelErrors(AddSubtractRequest model);
}
