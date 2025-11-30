using System.Data;
using Date_Calculator.Models.AddSubtract;
using Date_Calculator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Company.TestProject1;

[TestClass]
public class AddSubtractServiceTests
{
    private AddSubtractService _service = new AddSubtractService();

    [TestInitialize]
    public void Setup()
    {
    }

    [DataTestMethod]
    [DataRow(-10001, 4970, 0, 1, 0, 2, OperationType.Add, "Date cannot be more than 10,000 days before the current date.")]
    [DataRow(10001, 4970, 0, 1, 0, 2, OperationType.Add, "Date cannot be more than 10,000 days after the current date.")]
    [DataRow(0, 10001, 0, 0, 0, 0, OperationType.Add, "Cannot add or subtract more than 10,000 days to the date.")]
    [DataRow(0, 5, 0, 0, 0, -1, OperationType.Add, "Repeat number must be zero or more.")]
    [DataRow(0, -1, 0, 0, 0, 0, OperationType.Add, "The total number of days to add or subtract must be zero or more.")]
    public void ReturnModelErrors_ReturnsErrors(int dateOffset, int days, int weeks, int months, int years, int repeat, OperationType operation, string expectedError)
    {
        // Arrange
        var request = new AddSubtractRequest()
        {
            Date = DateTime.UtcNow.Date.AddDays(dateOffset),
            LengthOfTimeDays = days,
            LengthOfTimeWeeks = weeks,
            LengthOfTimeMonths = months,
            LengthOfTimeYears = years,
            Repeat = repeat,
            OperationType = operation
        };

        // Act
        var response = _service.ReturnModelErrors(request);

        // Assert
        Assert.IsTrue(response.ErrorMessages.Count == 1);
        Assert.AreEqual(response.ErrorMessages.First(), expectedError);
    }

    [DataTestMethod]
    [DataRow(-10000, 4970, 0, 1, 0, 2, OperationType.Add)]
    [DataRow(10000, 4970, 0, 1, 0, 2, OperationType.Add)]
    [DataRow(0, 10000, 0, 0, 0, 0, OperationType.Add)]
    [DataRow(0, 5, 0, 0, 0, 0, OperationType.Add)]
    [DataRow(0, 0, 0, 0, 0, 0, OperationType.Add)]
    public void ReturnModelErrors_ReturnsNoErrors(int dateOffset, int days, int weeks, int months, int years, int repeat, OperationType operation)
    {
        // Arrange
        var request = new AddSubtractRequest()
        {
            Date = DateTime.UtcNow.Date.AddDays(dateOffset),
            LengthOfTimeDays = days,
            LengthOfTimeWeeks = weeks,
            LengthOfTimeMonths = months,
            LengthOfTimeYears = years,
            Repeat = repeat,
            OperationType = operation
        };

        // Act
        var response = _service.ReturnModelErrors(request);

        // Assert
        Assert.IsTrue(response.ErrorMessages.Count == 0);
    }

    [TestMethod]
    public void CalculateNewDates_ReturnsModel_Zero()
    {
        // Arrange
        var request = new AddSubtractRequest()
        {
            Date = new DateTime(2025, 11, 30),
            LengthOfTimeDays = 0,
            LengthOfTimeWeeks = 0,
            LengthOfTimeMonths = 0,
            LengthOfTimeYears = 0,
            Repeat = 10001,
            OperationType = OperationType.Add
        };

        // Act
        var response = _service.CalculateNewDates(request);

        // Assert
        Assert.IsTrue(response.Results.Count == 1);
        Assert.AreEqual(response.Results.ElementAt(0), "Sunday, November 30, 2025");
    }

    [TestMethod]
    public void CalculateNewDates_ReturnsModel_Add()
    {
        // Arrange
        var request = new AddSubtractRequest()
        {
            Date = new DateTime(2025, 6, 1),
            LengthOfTimeDays = 6,
            LengthOfTimeWeeks = 2,
            LengthOfTimeMonths = 0,
            LengthOfTimeYears = 0,
            Repeat = 3,
            OperationType = OperationType.Add
        };

        // Act
        var response = _service.CalculateNewDates(request);

        // Assert
        Assert.IsTrue(response.Results.Count == 3);
        Assert.AreEqual(response.Results.ElementAt(0), "Saturday, June 21, 2025");
        Assert.AreEqual(response.Results.ElementAt(1), "Friday, July 11, 2025");
        Assert.AreEqual(response.Results.ElementAt(2), "Thursday, July 31, 2025");
    }

    [TestMethod]
    public void CalculateNewDates_ReturnsModel_Subtract()
    {
        // Arrange
        var request = new AddSubtractRequest()
        {
            Date = new DateTime(2025, 6, 1),
            LengthOfTimeDays = 6,
            LengthOfTimeWeeks = 2,
            LengthOfTimeMonths = 0,
            LengthOfTimeYears = 0,
            Repeat = 3,
            OperationType = OperationType.Subtract
        };

        // Act
        var response = _service.CalculateNewDates(request);

        // Assert
        Assert.IsTrue(response.Results.Count == 3);
        Assert.AreEqual(response.Results.ElementAt(0), "Monday, May 12, 2025");
        Assert.AreEqual(response.Results.ElementAt(1), "Tuesday, April 22, 2025");
        Assert.AreEqual(response.Results.ElementAt(2), "Wednesday, April 2, 2025");
    }

    [TestMethod]
    public void CalculateNewDates_ReturnsModel_NoRepeat()
    {
        // Arrange
        var request = new AddSubtractRequest()
        {
            Date = new DateTime(2025, 6, 1),
            LengthOfTimeDays = 6,
            LengthOfTimeWeeks = 2,
            LengthOfTimeMonths = 0,
            LengthOfTimeYears = 0,
            Repeat = 0,
            OperationType = OperationType.Add
        };

        // Act
        var response = _service.CalculateNewDates(request);

        // Assert
        Assert.IsTrue(response.Results.Count == 1);
        Assert.AreEqual(response.Results.ElementAt(0), "Saturday, June 21, 2025");
    }
}
