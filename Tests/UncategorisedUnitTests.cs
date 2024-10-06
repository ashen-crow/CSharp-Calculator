using Calculator;

namespace Tests;

// TODO: add more tests with brackets and negatives!
[TestClass]
public class UncategorisedUnitTests
{
    // TODO: Split this down into feature-centric test classes

    // Add and subtract, at equal operator precedence, precede by appearance order

    [TestMethod]
    [DataRow("3-4+2", "1")]
    [DataRow("3+4-2", "5")]
    public void CalculateAdditionsAndSubtractionsByOrderOfAppearance(string input, string expected)
    {
        var actual = MathCalculator.CalculateAdditionsAndSubtractionsByOrderOfAppearance(input);
        Assert.AreEqual(expected, actual);
    }

    //
}
