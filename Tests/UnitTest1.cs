using Calculator;

namespace Tests;

[TestClass]
public class UnitTest1 // TODO: rename this class to something more meaningful
{ // TODO: Split this down into feature-centric test classes
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

    // Subtract

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
        // Act
        bool actual = BasicEquationMatchers.IsMatchOfNumberMinusNumber(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3-4-5-2", "-8")]
    public void SubtractManyNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateSubtractionsAllowsForNegatives(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    // Add and subtract, at equal operator precedence, precede by appearance order

    [TestMethod]
    [DataRow("3-4+2", "1")]
    [DataRow("3+4-2", "5")]
    public void CalculateAdditionsAndSubtractionsByOrderOfAppearance(string input, string expected)
    {
        var actual = MathCalculator.CalculateAdditionsAndSubtractionsByOrderOfAppearance(input);
        Assert.AreEqual(expected, actual);
    }

    // Multiply

    [TestMethod]
    [DataRow("3*4", "12")]
    [DataRow("20.5*10", "205")]
    public void MultiplyTwoNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateFirstInstanceOfNumberMultipliedByNumber(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3*4", true)]
    public void IsMatchOfNumberMultipliedByNumber(string input, bool expected)
    {
        // Act
        bool actual = BasicEquationMatchers.IsMatchOfNumberMultipliedByNumber(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3*4*5*2", "120")]
    public void MultiplyManyNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateMultiplications(input);

        // Assert
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
