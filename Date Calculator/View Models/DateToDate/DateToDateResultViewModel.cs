using System;

namespace Date_Calculator.View_Models.DateToDate;

public class DateToDateResultViewModel
{
    public string DaysResult { get; set; } = string.Empty;
    public string WeeksResult { get; set; } = string.Empty;
    public string MonthsResult { get; set; } = string.Empty;
    public string YearsResult { get; set; } = string.Empty;
    public DateTime PreviousStartDate { get; set; } = DateTime.UtcNow.Date;
    public DateTime PreviousEndDate { get; set; } = DateTime.UtcNow.Date;
}
