using Calculator;

namespace Tests;

[TestClass]
public class AbsolutesTests
{
    [TestMethod]
    [DataRow("ABS(-70)", "70")]
    [DataRow("ABS(70)", "70")]
    public void CalculateFirstInstanceOfSingleNumberAbsolute(string input, string expected)
    {
        var actual = MathCalculator.CalculateFirstInstanceOfSingleNumberAbsolute(input);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("ABS(-60)", true)]
    [DataRow("ABS(-100000)", true)]
    [DataRow("ABS(100000)", true)]
    [DataRow("ABS(0)", true)]
    [DataRow("", false)]
    [DataRow("    ", false)]
    public void IsMatchOfSingleNumberAbsolute(string input, bool expected)
    {
        bool actual = BasicEquationMatchers.IsMatchOfSingleNumberAbsolute(input);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("ABS(70+40)", "110")]
    [DataRow("ABS(70-100)", "-30")]
    public void CalculateFirstInstanceOfEquationAbsolute(string input, string expected)
    {
        var actual = MathCalculator.CalculateFirstInstanceOfBasicEquationAbsolute(input);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("ABS(70+40)", true)]
    [DataRow("ABS(70-100)", true)]
    public void IsMatchOfAdvancedAbsolute(string input, bool expected)
    {
        bool actual = BasicEquationMatchers.IsMatchOfAdvancedAbsolute(input);

        Assert.AreEqual(expected, actual);
    }
}
