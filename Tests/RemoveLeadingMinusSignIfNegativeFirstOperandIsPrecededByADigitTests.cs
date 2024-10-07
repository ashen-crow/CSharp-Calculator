using Calculator;

//using FluentAssertions;
namespace Tests;

[TestClass]
public class RemoveLeadingMinusSignIfNegativeFirstOperandIsPrecededByADigitTests
{
    // Add
    [TestMethod]
    [DataRow("3-1-1", "-1-1", "1-1")]
    [DataRow("2+-1-1", "-1-1", "-1-1")]
    [DataRow("5-10^-120", "-10^-120", "10^-120")]
    public void RemoveFakeNegatives(string input, string substring, string expected)
    {
        /* Need to add a function to ensure that negatives are
        real negatives! if the character before a negative
         first operand is a digit, the first operand is not negative
        */
        string actual = FakeNegativesRemover.RemoveFakeNegativesFromFirstInstanceOfSubstring(
            input,
            substring
        );
        Assert.AreEqual(expected, actual);
        ///actual
        ///    .Should()
        ///    .Be(expected);
    }
}
