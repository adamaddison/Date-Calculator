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
}
