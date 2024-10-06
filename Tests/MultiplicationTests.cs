using Calculator;

namespace Tests;

[TestClass]
public class MultiplicationTests
{
    [TestMethod]
    [DataRow("3*4", "12")]
    [DataRow("20.5*10", "205")]
    public void MultiplyTwoNumbers(string input, string expected)
    {
        string actual = MathCalculator.CalculateFirstInstanceOfNumberMultipliedByNumber(input);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3*4", true)]
    public void IsMatchOfNumberMultipliedByNumber(string input, bool expected)
    {
        bool actual = BasicEquationMatchers.IsMatchOfNumberMultipliedByNumber(input);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3*4*5*2")]
    public void MultiplyManyNumbers(string input)
    {
        string actual = MathCalculator.CalculateMultiplications(input);

        Assert.AreEqual("120", actual);
    }

    [TestMethod]
    [DataRow("-3*2", "-6")]
    [DataRow("-3*-2", "6")]
    public void MultiplyManyNumbersHandlesNegatives(string input, string expected)
    {
        string actual = MathCalculator.CalculateMultiplications(input);

        Assert.AreEqual(expected, actual);
    }
}
