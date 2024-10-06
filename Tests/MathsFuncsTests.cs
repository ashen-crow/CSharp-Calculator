namespace Tests;

[TestClass]
public class MathsUtilsTests
{
    [TestMethod]
    [DataRow(10, 2, 12)]
    [DataRow(120_000, 30.0, 120_030)]
    public void Add(double a, double b, double expected)
    {
        var actual = Calculator.MathsUtils.Add(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(100, 2, 98)]
    [DataRow(120_000, 30.0, 119_970)]
    public void Subtract(double a, double b, double expected)
    {
        var actual = Calculator.MathsUtils.Subtract(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(100, 0.5, 50)]
    [DataRow(30, 40, 1200)]
    public void Multiply(double a, double b, double expected)
    {
        var actual = Calculator.MathsUtils.Multiply(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("100", "0.5", 50)]
    [DataRow("30", "40", 1200)]
    public void MultiplyStringifiedNumbers(string a, string b, double expected)
    {
        var actual = Calculator.MathsUtils.MultiplyStringifiedNumbers(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(100, 0.5, 200)]
    [DataRow(30, 40, 0.75)]
    public void Divide(double a, double b, double expected)
    {
        var actual = Calculator.MathsUtils.Divide(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("100", "0.5", 200)]
    [DataRow("30", "40", 0.75)]
    public void DivideStringifiedNumbers(string a, string b, double expected)
    {
        var actual = Calculator.MathsUtils.DivideStringifiedNumbers(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(100, 100)]
    [DataRow(-9999, 9999)]
    public void Abs(double a, double expected)
    {
        var actual = Calculator.MathsUtils.Abs(a);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("10", "2", 12)]
    [DataRow("120000", "30.0", 120_030)]
    [DataRow("120000", "-30.0", 119_970)]
    public void AddStringifiedNumbers(string a, string b, double expected)
    {
        var actual = Calculator.MathsUtils.AddStringifiedNumbers(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(2, 2, 4)]
    [DataRow(2, -2, 0.25)]
    public void Pow(double a, double b, double expected)
    {
        var actual = Calculator.MathsUtils.Pow(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("10", "2", 100)]
    [DataRow("3", "3", 27)]
    [DataRow("-3", "3", -27)]
    [DataRow("-3", "-3", -0.037037037037037035)]
    [DataRow("1", "-2", 1)]
    public void PowOfStringifiedNumbers(string a, string b, double expected)
    {
        var actual = Calculator.MathsUtils.PowOfStringifiedNumbers(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("10.002", 10.002)]
    [DataRow("-10.002", 10.002)]
    public void AbsOfStringifiedNumber(string a, double expected)
    {
        var actual = Calculator.MathsUtils.AbsOfStringifiedNumber(a);
        Assert.AreEqual(expected, actual);
    }
}
