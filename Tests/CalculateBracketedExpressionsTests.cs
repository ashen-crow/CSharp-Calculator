using Calculator;

namespace Tests;

[TestClass]
public class CalculateBracketedExpressionsTests
{
    [TestMethod]
    public void CalculateFirstInstanceOfBracketedExpression()
    {
        Assert.Fail();
    }

    [TestMethod]
    [DataRow("(2^3)-2", "8-2")]
    [DataRow("(3^3)", "27")]
    public void CalculateFirstInstanceOfBracketedIndexationExpression(string input, string expected)
    {
        var actual =
            CalculateBracketedExpressions.CalculateFirstInstanceOfBracketedIndexationExpression(
                input
            );
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("20/(2/3)", "20/(0.6666666666666666)")]
    [DataRow("5+(3/2)", "5+(1.5)")]
    [DataRow("(4/5)*8", "(0.8)*8")]
    public void CalculateFirstInstanceOfBracketedDivisionExpression(string input, string expected)
    {
        var actual =
            BracketedAdditionExpressionReplacer.ReplaceFirstInstanceOfBracketedDivisionExpression(
                input
            );
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("20/(2*3)", "20/(6)")]
    [DataRow("5+(3*2)", "5+(6)")]
    [DataRow("(4*5)*8", "(20)*8")]
    [DataRow("12*(7*(3*9))", "12*(7*(27))")]
    [DataRow("((10*15)*3)*2", "((150)*3)*2")]
    [DataRow("30-(8*(2*1))", "30-(8*(2))")]
    [DataRow("20*(25-(8*(5*7)))", "20*(25-(8*(35)))")]
    [DataRow("10^(6*(3*7))", "10^(6*(21))")]
    [DataRow("((9*4)*(8*6))", "((36)*(8*6))")]
    [DataRow("25*(6*(9*(1*2)))", "25*(6*(9*(2)))")]
    [DataRow("((50*30)-(10*5))*4", "((1500)-(10*5))*4")]
    [DataRow("50^(6*(3*9))", "50^(6*(27))")]
    [DataRow("15*(6*(10*5))-4", "15*(6*(50))-4")]
    [DataRow("(8*(5*(2*3)))*(12*4)", "(8*(5*(6)))*(12*4)")]
    [DataRow("((3*5)*(4*6))-(7*(1*2))", "((15)*(4*6))-(7*(1*2))")]
    public void CalculateFirstInstanceOfBracketedMultiplicationExpression(
        string input,
        string expected
    )
    {
        var actual =
            BracketedAdditionExpressionReplacer.ReplaceFirstInstanceOfBracketedMultiplicationExpression(
                input
            );
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void CalculateFirstInstanceOfBracketedAdditionOrSubtractionExpression()
    {
        Assert.Fail();
    }

    [TestMethod]
    [DataRow("20/(2+3)", "20/(5)")]
    [DataRow("5+(3+2)", "5+(5)")]
    [DataRow("(4+5)+8", "(9)+8")]
    [DataRow("12+(7+(3+9))", "12+(7+(12))")]
    [DataRow("((10+15)+3)+2", "((25)+3)+2")]
    [DataRow("30-(8+(2+1))", "30-(8+(3))")]
    [DataRow("20+(25-(8+(5+7)))", "20+(25-(8+(12)))")]
    [DataRow("10^(6+(3+7))", "10^(6+(10))")]
    [DataRow("((9+4)+(8+6))", "((13)+(8+6))")]
    [DataRow("25+(6+(9+(1+2)))", "25+(6+(9+(3)))")]
    [DataRow("((50+30)-(10+5))+4", "((80)-(10+5))+4")]
    [DataRow("50^(6+(3+9))", "50^(6+(12))")]
    [DataRow("15+(6+(10+5))-4", "15+(6+(15))-4")]
    [DataRow("(8+(5+(2+3)))+(12+4)", "(8+(5+(5)))+(12+4)")]
    [DataRow("((3+5)+(4+6))-(7+(1+2))", "((8)+(4+6))-(7+(1+2))")]
    public void CalculateFirstInstanceOfBracketedAdditionExpression(string input, string expected)
    {
        var actual =
            BracketedAdditionExpressionReplacer.ReplaceFirstInstanceOfBracketedAdditionExpression(
                input
            );
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("20/(2-3)", "20/(-1)")]
    [DataRow("5+(3-2)", "5+(1)")]
    [DataRow("(4-5)-8", "(-1)-8")]
    [DataRow("12+(7+(3-9))", "12+(7+(-6))")]
    [DataRow("((10-15)-3)-2", "((-5)-3)-2")]
    [DataRow("30-(8+(2-1))", "30-(8+(1))")]
    [DataRow("20+(25-(8+(5-7)))", "20+(25-(8+(-2)))")]
    [DataRow("10^(6+(3-7))", "10^(6+(-4))")]
    [DataRow("((9-4)-(8-6))", "((5)-(8-6))")]
    [DataRow("25+(6+(9+(1-2)))", "25+(6+(9+(-1)))")]
    [DataRow("25+(6+(9+(20--30)))", "25+(6+(9+(50)))")]
    [DataRow("((50-30)-(10-5))+4", "((20)-(10-5))+4")]
    [DataRow("50^(6+(3-9))", "50^(6+(-6))")]
    [DataRow("15+(6+(10-5))-4", "15+(6+(5))-4")]
    [DataRow("(8+(5+(2-3)))+(12+4)", "(8+(5+(-1)))+(12+4)")]
    [DataRow("(8+(5+(2--3)))+(12+4)", "(8+(5+(5)))+(12+4)")]
    [DataRow("(8+(5+(-2--3)))+(12+4)", "(8+(5+(5)))+(12+4)")]
    [DataRow("((3-5)+(4-6))-(7+(1-2))", "((-2)+(4-6))-(7+(1-2))")]
    public void CalculateFirstInstanceOfBracketedSubtractionExpression(
        string input,
        string expected
    )
    {
        var actual =
            BracketedAdditionExpressionReplacer.ReplaceFirstInstanceOfBracketedSubtractionExpression(
                input
            );
        Assert.AreEqual(expected, actual);
    }
}
