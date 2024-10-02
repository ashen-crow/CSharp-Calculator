using Calculator;

namespace Tests;

[TestClass]
public class BasicExponentiationTests
{
    // Exponentiation

    [TestMethod]
    [DataRow("10^2", "100")]
    [DataRow("3^3", "27")]
    public void ExponentiationWithOnlyTwoNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateFirstInstanceOfNumberExponentiatedByNumber(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3^4", true)]
    [DataRow("1000^0.5", true)]
    public void IsMatchOfNumberExponentiatedByNumber(string input, bool expected)
    {
        // Act
        bool actual = BasicEquationMatchers.IsMatchOfNumberExponentiatedByNumber(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("2^2^2^2", "65536")]
    public void CalculateIndices(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateIndices(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
