using Date_Calculator.Models.DateToDate;
using Date_Calculator.Services;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Company.TestProject1;

[TestClass]
public class DateToDateServiceTests
{
    private DateToDateService _service = new DateToDateService();

    [TestInitialize]
    public void Setup()
    {
    }
    
    [DataTestMethod]
    [DataRow(6, "")]
    [DataRow(7, "1 week")]
    [DataRow(8, "1 week, 1 day")]
    [DataRow(9, "1 week, 2 days")]
    [DataRow(13, "1 week, 6 days")]
    [DataRow(14, "2 weeks")]
    [DataRow(15, "2 weeks, 1 day")]
    [DataRow(16, "2 weeks, 2 days")]
    public void GetWeeksResult_ReturnsWeeks(int days, string expected)
    {
        // Act
        var response = _service.GetWeeksResult(days);

        // Assert
        Assert.AreEqual(response, expected);
    }

    [DataTestMethod]
    [DataRow(29, "")]
    [DataRow(30, "1 month")]
    [DataRow(31, "1 month, 1 day")]
    [DataRow(32, "1 month, 2 days")]
    [DataRow(59, "1 month, 29 days")]
    [DataRow(60, "2 months")]
    [DataRow(61, "2 months, 1 day")]
    [DataRow(62, "2 months, 2 days")]
    public void GetMonthsResult_ReturnsMonths(int days, string expected)
    {
        // Act
        var response = _service.GetMonthsResult(days);

        // Assert
        Assert.AreEqual(response, expected);
    }

    [DataTestMethod]
    [DataRow(364, "")]
    [DataRow(365, "1 year")]
    [DataRow(366, "1 year, 1 day")]
    [DataRow(367, "1 year, 2 days")]
    [DataRow(394, "1 year, 29 days")]
    [DataRow(395, "1 year, 1 month")]
    [DataRow(396, "1 year, 1 month, 1 day")]
    [DataRow(730, "2 years")]
    [DataRow(731, "2 years, 1 day")]
    [DataRow(732, "2 years, 2 days")]
    [DataRow(759, "2 years, 29 days")]
    [DataRow(760, "2 years, 1 month")]
    [DataRow(761, "2 years, 1 month, 1 day")]
    public void GetYearsResult_ReturnsYears(int days, string expected)
    {
        // Act
        var response = _service.GetYearsResult(days);

        // Assert
        Assert.AreEqual(response, expected);
    }

    [DataTestMethod]
    [DataRow(-20001, -1, "Start date cannot be more than 20,000 days before the current date.")]
    [DataRow(-20000, 1, "End date cannot be more than 20,000 days after the start date.")]
    [DataRow(1, 20001, "End date cannot be more than 20,000 days after the current date.")]
    public void ReturnModelErrors_ReturnsErrors(int startDateOffset, int endDateOffset, string expectedError)
    {
        // Arrange
        var request = new DateToDateRequest()
        {
            StartDate = DateTime.UtcNow.Date.AddDays(startDateOffset),
            EndDate = DateTime.UtcNow.Date.AddDays(endDateOffset)
        };

        // Act
        var response = _service.ReturnModelErrors(request);

        // Assert
        Assert.IsTrue(response.ErrorMessages.Count == 1);
        Assert.AreEqual(response.ErrorMessages.First(), expectedError);
    }

    [DataTestMethod]
    [DataRow(-20000, -1)]
    [DataRow(-20000, 0)]
    [DataRow(0, 20000)]
    public void ReturnModelErrors_ReturnsNoErrors(int startDateOffset, int endDateOffset)
    {
        // Arrange
        var request = new DateToDateRequest()
        {
            StartDate = DateTime.UtcNow.Date.AddDays(startDateOffset),
            EndDate = DateTime.UtcNow.Date.AddDays(endDateOffset)
        };

        // Act
        var response = _service.ReturnModelErrors(request);

        // Assert
        Assert.IsTrue(response.ErrorMessages.Count == 0);
    }

    [DataTestMethod]
    [DataRow(5, 4)]
    [DataRow(5, 5)]
    public void ReturnModelErrors_SwapsDates(int startDateOffset, int endDateOffset)
    {
        // Arrange
        var request = new DateToDateRequest()
        {
            StartDate = DateTime.UtcNow.Date.AddDays(startDateOffset),
            EndDate = DateTime.UtcNow.Date.AddDays(endDateOffset)
        };

        // Act
        var response = _service.ReturnModelErrors(request);

        // Assert
        Assert.IsTrue(response.PreviousStartDate.Date <= response.PreviousEndDate.Date);
    }

    [TestMethod]
    public void CalculateTimeSpan_ReturnsModel()
    {
        // Arrange
        var request = new DateToDateRequest()
        {
            StartDate = new DateTime(2024, 10, 28),
            EndDate = new DateTime(2025, 11, 29)
        };

        // Act
        var response = _service.CalculateTimeSpan(request);

        // Assert
        Assert.AreEqual(response.DaysResult, "397 days");
        Assert.AreEqual(response.WeeksResult, "56 weeks, 5 days");
        Assert.AreEqual(response.MonthsResult, "13 months, 7 days");
        Assert.AreEqual(response.YearsResult, "1 year, 1 month, 2 days");
    }
}
