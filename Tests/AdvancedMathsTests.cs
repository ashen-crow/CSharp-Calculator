using Calculator;

namespace Tests;

[TestClass]
public class AdvancedMathsTests
{
    [TestMethod]
    [DataRow("2+3-1", "4")]
    [DataRow("2/4*10", "5")]
    [DataRow("10-ABS(-5)", "5")]
    [DataRow("10*ABS(-5*1/2)", "25")]
    [DataRow("3*2+4-10^5", "-99990")]
    public void CalculatesMixedBidmasExpressionWithoutBrackets(string input, string expected)
    {
        var actual = MathCalculator.ProcessBidmasExceptBracketsIteratively(input);

        Assert.AreEqual(expected, actual);
    }
}
