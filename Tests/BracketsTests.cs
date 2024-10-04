using Calculator;

namespace Tests
{
    [TestClass]
    public class BracketsTests
    {
        [TestMethod]
        [DataRow("(20)", "20")]
        [DataRow("(-20)", "-20")]
        public void SimplifiesBracketedOrphanNumber(string input, string expected)
        {
            var actual = MathCalculator.SimplifyBracketedOrphanedNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("ABS(20)", "ABS(20)")]
        [DataRow("ABS(-20)", "ABS(-20)")]
        public void DoesNotSimplifyUnaryMathsFunctions(string input, string expected)
        {
            var actual = MathCalculator.SimplifyBracketedOrphanedNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("(20+30-2)", "48")]
        [DataRow("(20-30+ABS(-2))", "-8")]
        public void SimplifiesBracketedExpression(string input, string expected)
        {
            var actual = MathCalculator.ResolveBracketedExpression(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
