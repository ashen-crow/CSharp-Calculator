using System.Text.RegularExpressions;
using Calculator;

public static class CalculateBracketedExpressions
{
    public static string CalculateFirstInstanceOfBracketedIndexationExpression(string input)
    {
        string result = input;
        var bracketedIndexationExpressionPattern = new Regex(
            @"\(" + BasicEquationMatchers.numberExponentiatedByNumberPattern.ToString() + @"\)"
        );
        var firstMatch = bracketedIndexationExpressionPattern.Match(result).Value;
        var calculatedResult =
            MathCalculator.CalculateFirstInstanceOfNumberExponentiatedByNumberCorrectly(firstMatch);

        return result;
    }
}
