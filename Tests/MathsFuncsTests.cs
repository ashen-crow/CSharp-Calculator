namespace Tests;

[TestClass]
public class MathsFuncsTests
{
    [TestMethod]
    [DataRow(10, 2, 12)]
    [DataRow(120_000, 30.0, 120_030)]
    public void Add(double a, double b, double expected)
    {
        var actual = Calculator.MathsFuncs.Add(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(100, 2, 98)]
    [DataRow(120_000, 30.0, 119_970)]
    public void Subtract(double a, double b, double expected)
    {
        var actual = Calculator.MathsFuncs.Subtract(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(100, 0.5, 50)]
    [DataRow(30, 40, 1200)]
    public void Multiply(double a, double b, double expected)
    {
        var actual = Calculator.MathsFuncs.Multiply(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(100, 0.5, 200)]
    [DataRow(30, 40, 0.75)]
    public void Divide(double a, double b, double expected)
    {
        var actual = Calculator.MathsFuncs.Divide(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("10", "2", 12)]
    [DataRow("120000", "30.0", 120_030)]
    [DataRow("120000", "-30.0", 119_970)]
    public void AddStringifiedNumbers(string a, string b, double expected)
    {
        var actual = Calculator.MathsFuncs.AddStringifiedNumbers(a, b);
        Assert.AreEqual(expected, actual);
    }
}
