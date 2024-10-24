namespace Calculator.Tests;

[TestClass]
public class CalculateSingleNumberUnaryMathsFunctionsTest
{
    [TestMethod]
    public void CalculateSingleNumberAbsolutes_PositiveNumber_ReturnsSameNumber()
    {
        // Arrange
        string input = "ABS(5)";
        string expected = "5";

        // Act
        string result = CalculateSingleNumberUnaryMathsFunctions.CalculateSingleNumberAbsolutes(
            input
        );

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void CalculateSingleNumberAbsolutes_NegativeNumber_ReturnsAbsoluteValue()
    {
        // Arrange
        string input = "ABS(-5)";
        string expected = "5";

        // Act
        string result = CalculateSingleNumberUnaryMathsFunctions.CalculateSingleNumberAbsolutes(
            input
        );

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void CalculateSingleNumberAbsolutes_Zero_ReturnsZero()
    {
        // Arrange
        string input = "ABS(0)";
        string expected = "0";

        // Act
        string result = CalculateSingleNumberUnaryMathsFunctions.CalculateSingleNumberAbsolutes(
            input
        );

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void CalculateSingleNumberSquareRoots_PerfectSquare_ReturnsSquareRoot()
    {
        // Arrange
        string input = "SQRT(4)";
        string expected = "2";

        // Act
        string result = CalculateSingleNumberUnaryMathsFunctions.CalculateSingleNumberSquareRoots(
            input
        );

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void CalculateSingleNumberSquareRoots_NonPerfectSquare_ReturnsApproximateSquareRoot()
    {
        // Arrange
        string input = "SQRT(2)";
        string expected = "1.41421356237"; // Approximate value

        // Act
        string result = CalculateSingleNumberUnaryMathsFunctions.CalculateSingleNumberSquareRoots(
            input
        );

        // Assert
        Assert.AreEqual(expected, result.Substring(0, 13)); // Compare up to x decimal places
    }

    [TestMethod]
    public void CalculateSingleNumberSquareRoots_Zero_ReturnsZero()
    {
        // Arrange
        string input = "SQRT(0)";
        string expected = "0";

        // Act
        string result = CalculateSingleNumberUnaryMathsFunctions.CalculateSingleNumberSquareRoots(
            input
        );

        // Assert
        Assert.AreEqual(expected, result);
    }
}
