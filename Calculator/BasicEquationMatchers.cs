using System.Text.RegularExpressions;

namespace Calculator;

public static class BasicEquationMatchers
{
    public const string mathsFunctionKeywordsToIgnore = @"(ABS|ROUND|SQRT|CEIL|FLOOR|TRUNC)";

    public static readonly Regex bracketedOrphanedNumberPattern = new Regex(
        @$"(?<!{mathsFunctionKeywordsToIgnore})\(\{MathCalculator.numberSubPatternWithOptionalNegative}\)"
    );

    public static readonly Regex repeatedPlusSignPattern = new Regex(
        $@"{MathCalculator.escapedPlusSign}+"
    );

    public static readonly Regex firstMatchOfNumberMultipliedByNumber = new Regex(
        $@"{MathCalculator.numberSubPatternWithOptionalNegative}{MathCalculator.escapedMultiplySign}{MathCalculator.numberSubPatternWithOptionalNegative}"
    );

    public static readonly Regex numberPlusNumberWithOptionalFirstNegativeNumberPattern = new Regex(
        MathCalculator.startOfStringOrLineOrBracketedExpressionPattern
            + MathCalculator.numberSubPatternWithOptionalNegative
            + MathCalculator.allOperatorsEscaped
            + MathCalculator.numberSubPattern
    );

    public static readonly Regex numberexponentiatedByNumberPattern = new Regex(
        $@"{MathCalculator.numberSubPatternWithOptionalNegative}({MathCalculator.escapedExponentiationSign}{MathCalculator.numberSubPatternWithOptionalNegative})+"
    );

    public static readonly Regex numberDividedByNumberPattern = new Regex(
        $@"{MathCalculator.numberSubPatternWithOptionalNegative}{MathCalculator.escapedDivideSign}{MathCalculator.numberSubPatternWithOptionalNegative}"
    );

    public static readonly Regex singleNumberAbsolutePattern = new Regex(
        @"ABS\(" + MathCalculator.numberSubPatternWithOptionalNegative + @"\)",
        RegexOptions.IgnoreCase
    );

    public static readonly Regex numberMinusNumberAllowsNegativesPattern = new Regex(
        MathCalculator.startOfStringOrLineOrBracketedExpressionPattern
            + MathCalculator.numberSubPatternWithOptionalNegative
            + MathCalculator.escapedMinusSign
            + MathCalculator.numberSubPattern
    );

    public static readonly Regex AdvancedAbsPattern = new Regex(
        @"ABS\("
            + MathCalculator.numberSubPatternWithOptionalNegative
            + MathCalculator.allOperatorsEscaped
            + MathCalculator.numberSubPatternWithOptionalNegative
            + @"\)",
        RegexOptions.IgnoreCase
    );

    public static readonly Regex bracketedExpressionPattern = new Regex(
        @"\("
            + MathCalculator.numberSubPatternWithOptionalNegative
            + MathCalculator.allOperatorsEscaped
            + MathCalculator.numberSubPatternWithOptionalNegative
            + @"\)",
        RegexOptions.IgnoreCase
    );

    public static bool IsMatchOfNumberPlusNumber(string input)
    {
        return new Regex(
            $@"{MathCalculator.numberSubPattern}{MathCalculator.escapedPlusSign}{MathCalculator.numberSubPattern}"
        ).IsMatch(input);
    }

    public static bool IsMatchOfNumberMinusNumber(string input)
    {
        return new Regex(
            $@"{MathCalculator.numberSubPattern}{MathCalculator.escapedMinusSign}{MathCalculator.numberSubPattern}"
        ).IsMatch(input);
    }

    public static bool IsMatchOfNumberMinusNumberAllowsNegatives(string input)
    {
        return numberMinusNumberAllowsNegativesPattern.IsMatch(input);
    }

    public static bool IsMatchOfNumberMultipliedByNumber(string input)
    {
        return new Regex(
            $@"{MathCalculator.numberSubPatternWithOptionalNegative}{MathCalculator.escapedMultiplySign}{MathCalculator.numberSubPatternWithOptionalNegative}"
        ).IsMatch(input);
    }

    public static bool IsMatchOfNumberDividedByNumber(string input)
    {
        return numberDividedByNumberPattern.IsMatch(input);
    }

    public static bool IsMatchOfNumberModuloNumber(string input)
    {
        return new Regex(
            $@"{MathCalculator.numberSubPattern}{MathCalculator.escapedModuloSign}{MathCalculator.numberSubPattern}"
        ).IsMatch(input);
    }

    public static bool IsMatchOfSingleNumberAbsolute(string input)
    {
        return singleNumberAbsolutePattern.IsMatch(input);
    }

    public static string ExtractSingleNumberFromAbsolute(string input)
    {
        input = singleNumberAbsolutePattern.Match(input).Value.ToUpper();
        input = ExtractSingleNumberPositiveOrNegative(input);
        return input;
    }

    public static string ExtractSingleNumberPositiveOrNegative(string input)
    {
        return new Regex(MathCalculator.numberSubPatternWithOptionalNegative).Match(input).Value;
    }

    public static bool IsMatchOfNumberExponentiatedByNumber(string input)
    {
        return new Regex(
            $@"{MathCalculator.numberSubPattern}({MathCalculator.escapedExponentiationSign}{MathCalculator.numberSubPattern})+"
        ).IsMatch(input);
    }

    public static bool IsMatchOfAdvancedAbsolute(string input)
    {
        return AdvancedAbsPattern.IsMatch(input);
    }

    public static bool IsMatchOfBracketedOrphanedNumber(string input)
    {
        return bracketedOrphanedNumberPattern.IsMatch(input);
    }

    public static bool IsMatchOfBracketedExpression(string result)
    {
        return bracketedExpressionPattern.IsMatch(result);
    }
}
