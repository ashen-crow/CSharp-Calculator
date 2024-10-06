using Calculator;

namespace Tests;

[TestClass]
public class DivisionTests
{
    [TestMethod]
    [DataRow("3/4", "0.75")]
    [DataRow("20/10", "2")]
    public void DivideTwoNumbers(string input, string expected)
    {
        string actual = MathCalculator.CalculateFirstInstanceOfNumberDividedByNumber(input);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("-3/4", "-0.75")]
    [DataRow("20/-10", "-2")]
    [DataRow("-20/-10", "2")]
    public void DivideTwoNumbersHandlesNegatives(string input, string expected)
    {
        string actual = MathCalculator.CalculateFirstInstanceOfNumberDividedByNumber(input);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3/4", true)]
    public void IsMatchOfNumberDividedByNumber(string input, bool expected)
    {
        bool actual = BasicEquationMatchers.IsMatchOfNumberDividedByNumber(input);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3/4/5/2", "0.075")]
    public void DivideManyNumbers(string input, string expected)
    {
        string actual = MathCalculator.CalculateDivisions(input);

        Assert.AreEqual(expected, actual);
    }
}
