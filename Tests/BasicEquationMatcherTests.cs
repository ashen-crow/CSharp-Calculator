using Calculator;

namespace Tests;

[TestClass]
public class BasicEquationMatcherTests
{
    [TestMethod]
    [DataRow("ABS(-80)", "-80")]
    [DataRow("ABS(-21.2)", "-21.2")]
    [DataRow("ABS(200000)", "200000")]
    public void ExtractSingleNumberFromAbsolute(string input, string expected)
    {
        var actual = BasicEquationMatchers.ExtractSingleNumberFromAbsolute(input);

        Assert.AreEqual(expected, actual);
    }
}
