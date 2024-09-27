using Calculator;

namespace Tests;

[TestClass]
public class UnitTest1 // TODO: rename this class to something more meaningful
{
    [TestMethod]
    [DataRow("3+4", "7")]
    [DataRow("327.0+04", "331")]
    public void AddTwoNumbers(string input, string expected)
    {
        // Act
        string actual = MathCalculator.PLAN(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}