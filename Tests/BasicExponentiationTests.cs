using Calculator;

namespace Tests;

[TestClass]
public class BasicExponentiationTests
{
    // Exponentiation

    [TestMethod]
    [DataRow("10^2", "100")]
    [DataRow("3^3", "27")]
    [DataRow("-3^3", "-27")]
    [DataRow("-3^-3", "-0.03703704")]
    [DataRow("1^-2", "1")]
    public void ExponentiationWithOnlyTwoNumbers(string input, string expected)
    {
        string actual = MathCalculator.CalculateFirstInstanceOfNumberExponentiatedByNumberCorrectly(
            input
        );

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3^4", true)]
    [DataRow("1000^0.5", true)]
    public void IsMatchOfNumberExponentiatedByNumber(string input, bool expected)
    {
        bool actual = BasicEquationMatchers.IsMatchOfNumberExponentiatedByNumber(input);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("2^2^2^2", "65536")]
    public void CalculateIndices(string input, string expected)
    {
        string actual = MathCalculator.CalculateIndices(input);

        Assert.AreEqual(expected, actual);
    }
}
