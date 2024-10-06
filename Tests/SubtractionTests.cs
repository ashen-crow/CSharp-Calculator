using Calculator;

namespace Tests;

[TestClass]
public class SubtractionTests
{
    [TestMethod]
    [DataRow("-2-7", "-9")]
    [DataRow("-330.67-30.03", "-360.7")]
    public static void SubtractTwoNumbersHandlesNegatives(string input, string expected)
    {
        string actual = MathCalculator.CalculateFirstInstanceOfNumberMinusNumberIncludingNegatives(
            input
        );
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3-4", true)]
    public void IsMatchOfNumberMinusNumber(string input, bool expected)
    {
        bool actual = BasicEquationMatchers.IsMatchOfNumberMinusNumber(input);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3-4-5-2", "-8")]
    public void SubtractManyNumbers(string input, string expected)
    {
        string actual = MathCalculator.CalculateSubtractionsAllowsForNegatives(input);

        Assert.AreEqual(expected, actual);
    }
}
