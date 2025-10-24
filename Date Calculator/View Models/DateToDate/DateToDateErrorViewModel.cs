using System;

namespace Date_Calculator.View_Models.DateToDate;

public class DateToDateErrorViewModel
{
    public List<string> ErrorMessages { get; set; } = new List<string>();
    public DateTime PreviousStartDate { get; set; } = DateTime.UtcNow.Date;
    public DateTime PreviousEndDate { get; set; } = DateTime.UtcNow.Date;
}
