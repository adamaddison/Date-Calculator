using System;
using Date_Calculator.Interfaces;
using Date_Calculator.Models.AddSubtract;
using Date_Calculator.View_Models.AddSubtract;

namespace Date_Calculator.Services;

public class AddSubtractService : IAddSubtractService
{
    public AddSubtractResultViewModel CalculateNewDates(AddSubtractRequest model)
    {
        var lengthOfTime = model.LengthOfTimeDays + (7 * model.LengthOfTimeWeeks) + (30 * model.LengthOfTimeMonths) + (365 * model.LengthOfTimeYears);

        // Skipping calculation if length of time to add / subtract is zero and just returning date back
        if (lengthOfTime == 0)
        {
            return new AddSubtractResultViewModel()
            {
                Results = new List<string>() { model.Date.ToLongDateString() },
                Date = model.Date,
                LengthOfTimeDays = model.LengthOfTimeDays,
                LengthOfTimeWeeks = model.LengthOfTimeWeeks,
                LengthOfTimeMonths = model.LengthOfTimeMonths,
                LengthOfTimeYears = model.LengthOfTimeYears,
                Repeat = model.Repeat,
                OperationType = model.OperationType
            };
        }

        if (model.Repeat == 0) { model.Repeat = 1; }

        // Applying the add / subtract operation <model.Repeat> times and adding each result to an array
        var dateResults = new List<string>();
        for (var i = 1; i <= model.Repeat; i += 1)
        {
            if (model.OperationType == OperationType.Add)
            {
                var newDate = model.Date.Date.AddDays(i * lengthOfTime);
                dateResults.Add(newDate.ToLongDateString());
            }
            else
            {
                var newDate = model.Date.Date.AddDays(-1*(i * lengthOfTime));
                dateResults.Add(newDate.ToLongDateString());
            }
        }

        var response = new AddSubtractResultViewModel()
        {
            Results = new List<string>(dateResults),
            Date = model.Date,
            LengthOfTimeDays = model.LengthOfTimeDays,
            LengthOfTimeWeeks = model.LengthOfTimeWeeks,
            LengthOfTimeMonths = model.LengthOfTimeMonths,
            LengthOfTimeYears = model.LengthOfTimeYears,
            Repeat = model.Repeat,
            OperationType = model.OperationType
        };

        return response;
    }

    public AddSubtractErrorViewModel ReturnModelErrors(AddSubtractRequest model)
    {
        var currentDate = DateTime.UtcNow.Date;
        var currentDateMinus10KDays = currentDate.Add(TimeSpan.FromDays(-10000));
        var currentDatePlus10KDays = currentDate.Add(TimeSpan.FromDays(10000));
        var lengthOfTime = model.LengthOfTimeDays + (7 * model.LengthOfTimeWeeks) + (30 * model.LengthOfTimeMonths) + (365 * model.LengthOfTimeYears);

        var errorModel = new AddSubtractErrorViewModel()
        {
            Date = model.Date,
            LengthOfTimeDays = model.LengthOfTimeDays,
            LengthOfTimeWeeks = model.LengthOfTimeWeeks,
            LengthOfTimeMonths = model.LengthOfTimeMonths,
            LengthOfTimeYears = model.LengthOfTimeYears,
            Repeat = model.Repeat,
            OperationType = model.OperationType
        };
        
        if (model.Repeat == 0) { model.Repeat = 1; }

        if (!(model.Date >= currentDateMinus10KDays))
        {
            errorModel.ErrorMessages.Add("Date cannot be more than 10,000 days before the current date.");
        }

        if (!(model.Date <= currentDatePlus10KDays))
        {
            errorModel.ErrorMessages.Add("Date cannot be more than 10,000 days after the current date.");
        }

        if (!((lengthOfTime * model.Repeat) <= 10000))
        {
            errorModel.ErrorMessages.Add("Cannot add or subtract more than 10,000 days to the date.");
        }

        if (!(model.Repeat >= 0))
        {
            errorModel.ErrorMessages.Add("Repeat number must be zero or more.");
        }

        if (!(lengthOfTime >= 0))
        {
            errorModel.ErrorMessages.Add("The total number of days to add or subtract must be zero or more.");
        }

        return errorModel;
    }
}
