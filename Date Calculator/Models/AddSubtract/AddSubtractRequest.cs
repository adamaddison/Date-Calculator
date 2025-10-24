using System;

namespace Date_Calculator.Models.AddSubtract;

public class AddSubtractRequest
{
    public DateTime Date { get; set; } = DateTime.UtcNow.Date;
    public int LengthOfTimeDays { get; set; }
    public int LengthOfTimeWeeks { get; set; }
    public int LengthOfTimeMonths { get; set; }
    public int LengthOfTimeYears { get; set; }
    public int Repeat { get; set; }
    public OperationType OperationType { get; set; }
}
