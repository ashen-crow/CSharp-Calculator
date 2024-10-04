using Calculator;

namespace Tests
{
    [TestClass]
    public class ReplacerUtilityTests
    {
        [TestMethod]
        [DataRow("Hello", "l", "oi", "Heoilo")]
        [DataRow(
            "The quick brown fox jumps over the lazy gate",
            "quick",
            "swift",
            "The swift brown fox jumps over the lazy gate"
        )]
        [DataRow("2^2^2^2^2^2^2", "2^2", "4", "4^2^2^2^2^2")]
        public void OnlyFirstInstanceOfSubstringReplaced(
            string input,
            string substringToReplace,
            string replacement,
            string expected
        )
        {
            var actual = ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(
                input,
                substringToReplace,
                replacement
            );
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Hello", "l", "oi", "Heloio")]
        [DataRow(
            "The quickety quick brown fox jumps over the quick gate",
            "quick",
            "swift",
            "The quickety quick brown fox jumps over the swift gate"
        )]
        [DataRow("2^2^2^2^2^2^2", "2^2", "4", "2^2^2^2^2^4")]
        public void OnlyLastInstanceOfSubstringReplaced(
            string input,
            string substringToReplace,
            string replacement,
            string expected
        )
        {
            var actual = ReplacerUtility.ReplaceOnlyLastInstanceOfSubstring(
                input,
                substringToReplace,
                replacement
            );
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Hello", "l", "oi", "Heoioio")]
        [DataRow(
            "The quickety quick brown fox jumps over the quick gate",
            "quick",
            "swift",
            "The swiftety swift brown fox jumps over the swift gate"
        )]
        [DataRow("2^2^2^2^2^2^2", "2^2", "4", "4^4^4^2")]
        public void AllInstancesOfSubstringReplaced(
            string input,
            string substringToReplace,
            string replacement,
            string expected
        )
        {
            var actual = ReplacerUtility.ReplaceAllInstancesOfSubstring(
                input,
                substringToReplace,
                replacement
            );
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Hello world", "l", "Heo word")]
        public void RemoveAllInstancesOfSubstring(string input, string toRemove, string expected)
        {
            var actual = ReplacerUtility.RemoveAllInstancesOfSubstring(input, toRemove);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Hello world", "l", "Helo world")]
        public void RemoveOnlyFirstInstanceOfSubstring(
            string input,
            string toRemove,
            string expected
        )
        {
            var actual = ReplacerUtility.RemoveOnlyFirstInstanceOfSubstring(input, toRemove);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Hello world", "l", "Hello word")]
        public void RemoveOnlyLastInstanceOfSubstring(
            string input,
            string toRemove,
            string expected
        )
        {
            var actual = ReplacerUtility.RemoveOnlyLastInstanceOfSubstring(input, toRemove);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("(80)", "80")]
        [DataRow("(80.0)", "80.0")]
        [DataRow("(80.0-20)", "80.0-20")]
        [DataRow("(80.0-20+(2*70))", "80.0-20+(2*70)")]
        public void RemoveOutermostBrackets(string input, string expected)
        {
            var actual = ReplacerUtility.RemoveOutermostBrackets(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
