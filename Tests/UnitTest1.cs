using Calculator;

namespace Tests;

[TestClass]
public class UnitTest1 // TODO: rename this class to something more meaningful
{
    [TestMethod]
    [DataRow("3+4", "7")]
    [DataRow("327.0+04", "331")]
    public void AddTwoNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateFirstInstanceOfNumberPlusNumber(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3+4", true)]
    public void IsMatchOfNumberPlusNumber(string input, bool expected)
    {
        // Act
        bool actual = MathCalculator.IsMatchOfNumberPlusNumber(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3+4+5+2", "14")]
    public void ProcessBidmasExceptBrackets(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateAdditions(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3-4", "-1")]
    [DataRow("20-10", "10")]
    [DataRow("200-77.5", "122.5")]
    public void SubtractTwoNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateSubtractions(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}