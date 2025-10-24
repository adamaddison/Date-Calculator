using System;
using Date_Calculator.Interfaces;
using Date_Calculator.Models.DateToDate;
using Date_Calculator.View_Models.DateToDate;
using Microsoft.Extensions.ObjectPool;

namespace Date_Calculator.Services;

public class DateToDateService : IDateToDateService
{
    public DateToDateResultViewModel CalculateTimeSpan(DateToDateRequest model)
    {
        // Swapping date values if start date > end date
        if (model.StartDate > model.EndDate)
        {
            var startDateTemp = model.StartDate.Date;
            model.StartDate = model.EndDate.Date;
            model.EndDate = startDateTemp.Date;
        }

        var endDateMinusStartDate = model.EndDate.Date.Subtract(model.StartDate.Date);

        var viewModel = new DateToDateResultViewModel()
        {
            DaysResult = endDateMinusStartDate.Days == 1 ? endDateMinusStartDate.Days + " Day" : endDateMinusStartDate.Days + " Days",
            WeeksResult = GetWeeksResult(endDateMinusStartDate.Days),
            MonthsResult = GetMonthsResult(endDateMinusStartDate.Days),
            YearsResult = GetYearsResult(endDateMinusStartDate.Days),
            PreviousStartDate = model.StartDate.Date,
            PreviousEndDate = model.EndDate.Date
        };

        return viewModel;
    }

    public string GetWeeksResult(int days)
    {
        if (days < 7)
        {
            return "";
        }

        var weeks = Math.Truncate(days / 7.0);
        var daysRemaining = days % 7;

        if (daysRemaining == 0)
        {
            return weeks == 1 ? weeks + " week" : weeks + " weeks";
        }

        return (weeks == 1 ? weeks + " week" : weeks + " weeks") + (daysRemaining == 1 ? ", " + daysRemaining + " day" : ", " + daysRemaining + " days");
    }

    public string GetMonthsResult(int days)
    {
        if (days < 30)
        {
            return "";
        }

        var months = Math.Truncate(days / 30.0);
        var daysRemaining = days % 30;

        if (daysRemaining == 0)
        {
            return months == 1 ? months + " month" : months + " months";
        }

        return (months == 1 ? months + " month" : months + " months") + (daysRemaining == 1 ? ", " + daysRemaining + " day" : ", " + daysRemaining + " days");
    }

    public string GetYearsResult(int days)
    {
        if (days < 365)
        {
            return "";
        }

        var years = Math.Truncate(days / 365.0);

        if ((days % 365) == 0)
        {
            return years == 1 ? years + " year" : years + " years";
        }

        if ((days % 365) < 30)
        {
            return (years == 1 ? years + " year" : years + " years") + ((days % 365) == 1 ? (", " + (days % 365) + " day") : (", " + (days % 365) + " days"));
        }

        var monthsAndDays = GetMonthsResult(days % 365);

        return (years == 1 ? years + " year" : years + " years") + ", " + monthsAndDays;
    }

    public DateToDateErrorViewModel ReturnModelErrors(DateToDateRequest model)
    {
        // Swapping date values if start date > end date
        if (model.StartDate > model.EndDate)
        {
            var startDateTemp = model.StartDate.Date;
            model.StartDate = model.EndDate.Date;
            model.EndDate = startDateTemp.Date;
        }

        var currentDate = DateTime.UtcNow.Date;
        var currentDateMinus20KDays = currentDate.Add(TimeSpan.FromDays(-20000));
        var currentDatePlus20KDays = currentDate.Add(TimeSpan.FromDays(20000));
        var errorModel = new DateToDateErrorViewModel() { PreviousStartDate = model.StartDate.Date, PreviousEndDate = model.EndDate.Date };

        if (!(model.StartDate.Date >= currentDateMinus20KDays))
        {
            errorModel.ErrorMessages.Add("Start date cannot be more than 20,000 days before the current date.");
        }

        if (!(model.EndDate.Date <= currentDatePlus20KDays))
        {
            errorModel.ErrorMessages.Add("End date cannot be more than 20,000 days after the current date.");
        }

        if (!(model.EndDate.Date.Subtract(model.StartDate.Date).Days <= 20000))
        {
            errorModel.ErrorMessages.Add("End date cannot be more than 20,000 days after the start date.");
        }

        return errorModel;
    }
}
