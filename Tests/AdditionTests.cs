using Calculator;

namespace Tests;

[TestClass]
public class AdditionTests
{
    // Add

    [TestMethod]
    [DataRow("3+4", "7")]
    [DataRow("327.0+04", "331")]
    public void AddTwoNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateFirstInstanceOfNumberPlusNumberIncludingNegatives(
            input
        );

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("-30+20", "-10")]
    [DataRow("-100+2", "-98")]
    [DataRow("-100+200", "100")]
    public void AddTwoNumbersHandlesNegatives(string input, string expected)
    {
        string actual = MathCalculator.CalculateFirstInstanceOfNumberPlusNumberIncludingNegatives(
            input
        );
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3+4", true)]
    public void IsMatchOfNumberPlusNumber(string input, bool expected)
    {
        // Act
        bool actual = BasicEquationMatchers.IsMatchOfNumberPlusNumber(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3+4+5+2", "14")]
    public void AddManyNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateAdditionsAndSubtractionsByOrderOfAppearance(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
