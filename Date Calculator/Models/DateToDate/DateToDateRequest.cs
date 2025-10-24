using System;

namespace Date_Calculator.Models.DateToDate;

public class DateToDateRequest
{
    public DateTime StartDate { get; set; } = DateTime.UtcNow.Date;
    public DateTime EndDate { get; set; } = DateTime.UtcNow.Date;
}
