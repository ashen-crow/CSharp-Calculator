namespace Calculator
{
    public static class FakeNegativesRemover
    {
        public static string RemoveFakeNegativesFromFirstInstanceOfSubstring(
            string input,
            string substring
        )
        {
            string result = substring;
            // TODO: Refactor to use ReplacerUtility
            if (
                !input.Contains(substring)
                || input.Length <= substring.Length
                || input.StartsWith(substring)
            )
            {
                return result;
            }
            if (char.IsDigit(input[input.IndexOf(substring) - 1]))
            {
                result = ReplacerUtility.RemoveLeadingMinusSignNoChecks(substring);
            }
            return result;
        }
    }
}
