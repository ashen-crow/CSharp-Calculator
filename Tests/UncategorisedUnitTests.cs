using Calculator;

namespace Tests;

// TODO: add more tests with brackets and negatives!
[TestClass]
public class UncategorisedUnitTests
{
    // TODO: Split this down into feature-centric test classes

    // Add and subtract, at equal operator precedence, precede by appearance order

    [TestMethod]
    [DataRow("3-4+2", "1")]
    [DataRow("3+4-2", "5")]
    public void CalculateAdditionsAndSubtractionsByOrderOfAppearance(string input, string expected)
    {
        var actual = MathCalculator.CalculateAdditionsAndSubtractionsByOrderOfAppearance(input);
        Assert.AreEqual(expected, actual);
    }

    // Divide

    [TestMethod]
    [DataRow("3/4", "0.75")]
    [DataRow("20/10", "2")]
    public void DivideTwoNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateFirstInstanceOfNumberDividedByNumber(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("-3/4", "-0.75")]
    [DataRow("20/-10", "-2")]
    [DataRow("-20/-10", "2")]
    public void DivideTwoNumbersHandlesNegatives(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateFirstInstanceOfNumberDividedByNumber(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3/4", true)]
    public void IsMatchOfNumberDividedByNumber(string input, bool expected)
    {
        // Act
        bool actual = BasicEquationMatchers.IsMatchOfNumberDividedByNumber(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3/4/5/2", "0.075")]
    public void DivideManyNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateDivisions(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    // Absolute: basic

    [TestMethod]
    [DataRow("ABS(-70)", "70")]
    [DataRow("ABS(70)", "70")]
    public void CalculateFirstInstanceOfSingleNumberAbsolute(string input, string expected)
    {
        // Act
        var actual = MathCalculator.CalculateFirstInstanceOfSingleNumberAbsolute(input);

        // Assert
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
        // Act
        bool actual = BasicEquationMatchers.IsMatchOfSingleNumberAbsolute(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    // Absolute: advanced

    [TestMethod]
    [DataRow("ABS(70+40)", "110")]
    [DataRow("ABS(70-100)", "-30")]
    public void CalculateFirstInstanceOfEquationAbsolute(string input, string expected)
    {
        // Act
        var actual = MathCalculator.CalculateFirstInstanceOfBasicEquationAbsolute(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("ABS(70+40)", true)]
    [DataRow("ABS(70-100)", true)]
    public void IsMatchOfAdvancedAbsolute(string input, bool expected)
    {
        // Act
        bool actual = BasicEquationMatchers.IsMatchOfAdvancedAbsolute(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
