using System;
using Date_Calculator.Models.DateToDate;
using Date_Calculator.View_Models.DateToDate;

namespace Date_Calculator.Interfaces;

public interface IDateToDateService
{
    public DateToDateErrorViewModel ReturnModelErrors(DateToDateRequest model);
    public DateToDateResultViewModel CalculateTimeSpan(DateToDateRequest model);
}
