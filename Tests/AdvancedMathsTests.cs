using Calculator;

namespace Tests;

[TestClass]
public class AdvancedMathsTests
{
    [TestMethod]
    [DataRow("2+3-1", "4")]
    [DataRow("2-3+1", "0")]
    [DataRow("-2-3+1", "-4")]
    [DataRow("2/4*10", "5")]
    [DataRow("10-ABS(-5)", "5")]
    [DataRow("10*ABS(-5*1/2)", "25")]
    [DataRow("3*2+4-10^5", "-99990")]
    //
    [DataRow("(2+3-1)", "4")]
    [DataRow("2+3-1", "4")]
    [DataRow("2-3+1", "0")]
    [DataRow("-2-3+1", "-4")]
    [DataRow("2/4*10", "5")]
    [DataRow("10-ABS(-5)", "5")]
    [DataRow("10*ABS(-5*1/2)", "25")]
    [DataRow("3*2+4-10^5", "-99990")]
    [DataRow("10/2+3*4", "17")]
    [DataRow("5*10-3^2", "41")]
    [DataRow("ABS(-2+3*2)-4", "0")]
    [DataRow("10/2^2+5", "7.5")]
    [DataRow("SQRT(16)+2^3", "12")]
    [DataRow("5*(3+2)-10", "15")]
    [DataRow("2^3+3^2", "17")]
    public void CalculatesMixedBidmasExpressionWithoutBrackets(string input, string expected)
    {
        var actual = MathCalculator.ProcessBidmasExceptBracketsIteratively(input);

        Assert.AreEqual(expected, actual);
    }
}
