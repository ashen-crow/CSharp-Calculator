using Calculator;

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
    [DataRow("10.002", 10.002)]
    [DataRow("-10.002", 10.002)]
    public void AbsOfStringifiedNumber(string a, double expected)
    {
        var actual = Calculator.MathsUtils.AbsOfStringifiedNumber(a);
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
    [DataRow(10.5, 11)]
    [DataRow(10.4, 10)]
    [DataRow(10.55, 11)]
    [DataRow(10.54, 11)]
    [DataRow(123.456, 123)]
    [DataRow(123.454, 123)]
    public void Round(double value, double expected)
    {
        //Assert.Fail();
        var actual = Calculator.MathsUtils.RoundToNearestInteger(value);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("10.5", 11)]
    [DataRow("10.4", 10)]
    [DataRow("10.55", 10.6)]
    [DataRow("10.54", 10.5)]
    [DataRow("123.456", 123.46)]
    [DataRow("123.454", 123.45)]
    public void RoundStringifiedNumber(string value, double expected)
    {
        //Assert.Fail();
        var actual = Calculator.MathsUtils.RoundToNearestIntegerStringifiedNumber(value);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(100, 10)]
    public void Sqrt(double a, double expected)
    {
        Assert.AreEqual(expected, MathsUtils.SquareRoot(a));
    }

    [TestMethod]
    [DataRow("9", 3)]
    public void SqrtOfStringifiedNumber(string a, double expected)
    {
        Assert.AreEqual(expected, MathsUtils.SquareRootOfStringifiedNumber(a));
    }

    [TestMethod]
    [DataRow(4.99999, 5)]
    [DataRow(9999.01, 10_000)]
    public void Ceil(double a, double expected)
    {
        Assert.AreEqual(expected, MathsUtils.Ceil(a));
    }

    [TestMethod]
    [DataRow("5.04", 6)]
    public void CeilOfStringifiedNumber(string a, double expected)
    {
        Assert.AreEqual(expected, MathsUtils.CeilOfStringifiedNumber(a));
    }

    [TestMethod]
    [DataRow(2.9999999, 2)]
    [DataRow(74746557.02, 74746557)]
    public void Floor(double a, double expected)
    {
        Assert.AreEqual(expected, MathsUtils.Floor(a));
    }

    [TestMethod]
    [DataRow("200.0000001", 200)]
    [DataRow("24.99999", 24)]
    public void FloorOfStringifiedNumber(string a, double expected)
    {
        Assert.AreEqual(expected, MathsUtils.FloorOfStringifiedNumber(a));
    }

    [TestMethod]
    [DataRow(20.000001, 20)]
    [DataRow(Math.PI, 3)]
    public void Truncate(double a, double expected)
    {
        var actual = MathsUtils.Truncate(a);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("35.999999", 35)]
    [DataRow("202.1", 202)]
    public void TruncateOfStringifiedNumber(string a, double expected)
    {
        var actual = MathsUtils.TruncateOfStringifiedNumber(a);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(10, 2, 0)]
    [DataRow(3, 2, 1)]
    public void Modulo(double a, double b, double expected)
    {
        var actual = MathsUtils.Modulo(a, b);
    }

    [TestMethod]
    [DataRow("25", "4", 1)]
    public void ModuloOfStringifiedNumber(string a, string b, double expected)
    {
        Assert.Fail();
    }
}
