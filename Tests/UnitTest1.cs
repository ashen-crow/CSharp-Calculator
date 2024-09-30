using Calculator;

namespace Tests;

[TestClass]
public class UnitTest1 // TODO: rename this class to something more meaningful
{
    // Add

    [TestMethod]
    [DataRow("3+4", "7")]
    [DataRow("327.0+04", "331")]
    public void AddTwoNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateFirstInstanceOfNumberPlusNumber(input);

        // Assert
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
        string actual = MathCalculator.CalculateAdditions(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    // Add

    [TestMethod]
    [DataRow("3-4", "-1")]
    [DataRow("20-10", "10")]
    [DataRow("200-77.5", "122.5")]
    public void SubtractTwoNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.CalculateFirstInstanceOfNumberMinusNumber(input);

        // Assert
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
        string actual = MathCalculator.CalculateSubtractions(input);

        // Assert
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
    [DataRow("ABS(70+40)", true)]
    public void IsMatchOfMiniEquationAbsolute(string input, bool expected)
    {
        // Act
        bool actual = BasicEquationMatchers.IsMatchOfSingleNumberAbsolute(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
