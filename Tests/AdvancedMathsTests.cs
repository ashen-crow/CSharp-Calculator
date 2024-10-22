using Calculator;

namespace Tests;

[TestClass]
public class AdvancedMathsTests
{
    [TestMethod]
    [DataRow("2+3-1", "4")]
    [DataRow("2-3+1", "0")]
    [DataRow("-2-3+1", "-4")]
    [DataRow("2/4*10", "5")]
    [DataRow("10-ABS(-5)", "5")]
    [DataRow("10*ABS(-5*1/2)", "25")]
    [DataRow("3*2+4-10^5", "-99990")]
    //
    [DataRow("(2+3-1)", "4")]
    [DataRow("2+3-1", "4")]
    [DataRow("2-3+1", "0")]
    [DataRow("-2-3+1", "-4")]
    [DataRow("2/4*10", "5")]
    [DataRow("10-ABS(-5)", "5")]
    [DataRow("10*ABS(-5*1/2)", "25")]
    [DataRow("3*2+4-10^5", "-99990")]
    [DataRow("10/2+3*4", "17")]
    [DataRow("5*10-3^2", "41")]
    [DataRow("ABS(-2+3*2)-4", "0")]
    [DataRow("10/2^2+5", "7.5")]
    [DataRow("SQRT(16)+2^3", "12")]
    [DataRow("5*(3+2)-10", "15")]
    [DataRow("2^3+3^2", "17")]
    public void CalculatesMixedBidmasExpressionWithoutBrackets(string input, string expected)
    {
        var actual = MathCalculator.ProcessBidmasExceptBracketsIteratively(input);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("2+3-1", "4")]
    [DataRow("2-3+1", "0")]
    [DataRow("-2-3+1", "-4")]
    [DataRow("2/4*10", "5")]
    [DataRow("3*2+4-10^5", "-99990")]
    [DataRow("10/2+3*4", "17")]
    [DataRow("5*10-3^2", "41")]
    [DataRow("10/2^2+5", "7.5")]
    [DataRow("5*(3+2)-10", "15")]
    [DataRow("2^3+3^2", "17")]
    [DataRow("(2+3)*4", "20")]
    [DataRow("(2-3)*5", "-5")]
    [DataRow("(3*4)/2", "6")]
    [DataRow("3*(2+1)-4", "5")]
    [DataRow("10/(5-3)", "5")]
    [DataRow("(4+2)*(5-1)", "24")]
    [DataRow("10/2^2", "2.5")]
    [DataRow("5*2-3*4", "-2")]
    [DataRow("(10-3)*(4+1)", "35")]
    [DataRow("20/(5+5)", "2")]
    [DataRow("(5*(2+3))-10", "15")]
    [DataRow("10/(2+3*2)", "1.25")]
    [DataRow("(3+2)*(2-1)", "5")]
    [DataRow("((2+3)*4)-10", "10")]
    [DataRow("((5-2)*3)+4", "13")]
    [DataRow("20/(4-2)*3", "30")]
    [DataRow("10/(2+3)-1", "1")]
    [DataRow("((2+3)*4)/2", "10")]
    [DataRow("(3*(4+1))-2", "13")]
    [DataRow("(((2+3)*4)/2)-5", "5")]
    [DataRow("(5*(2+3))-((2+2)*3)", "13")]
    [DataRow("(10/(5-3))-2", "3")]
    [DataRow("((2*3)+(4/2))-1", "7")]
    [DataRow("(2+(3*(4-1)))", "11")]
    [DataRow("(5*(2+3))-((4/2)*3)", "19")]
    [DataRow("((4+1)*2)-((2+3)*1)", "5")]
    [DataRow("3*(2+(1*(4-3)))", "9")]
    [DataRow("4*((2+3)-2)", "12")]
    [DataRow("10/((2+3)*2)", "1")]
    [DataRow("(5*(2+3))/(2+3)", "5")]
    [DataRow("((2+3)*(4-1))/(2+2)", "3.75")]
    [DataRow("3*(2+((3-1)*2))", "18")]
    [DataRow("(10/2)+((3*4)-5)", "12")]
    [DataRow("(2+3)*((4-2)*3)", "30")]
    [DataRow("(((2+3)*4)-5)/3", "5")]
    [DataRow("5+(3*((2-1)+3))", "17")]
    [DataRow("(4*3)-((2+3)*2)", "2")]
    [DataRow("2+(3*(4-(2+1)))", "5")]
    [DataRow("(((2+3)*4)-10)/2", "5")]
    public void CalculatesMixedBidmasExpressionWithBrackets(string input, string expected)
    {
        var actual = MathCalculator.ProcessBidmasExceptBracketsIteratively(input);

        Assert.AreEqual(expected, actual);
    }
}
