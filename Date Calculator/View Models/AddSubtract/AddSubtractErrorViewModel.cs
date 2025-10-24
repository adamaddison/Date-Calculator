using System;
using Date_Calculator.Models.AddSubtract;

namespace Date_Calculator.View_Models.AddSubtract;

public class AddSubtractErrorViewModel
{
    public List<string> ErrorMessages { get; set; } = new List<string>();
    public DateTime Date { get; set; } = DateTime.UtcNow.Date;
    public int LengthOfTimeDays { get; set; }
    public int LengthOfTimeWeeks { get; set; }
    public int LengthOfTimeMonths { get; set; }
    public int LengthOfTimeYears { get; set; }
    public int Repeat { get; set; }
    public OperationType OperationType { get; set; }
}
