using System.Text.RegularExpressions;

namespace Calculator;

public static class BasicEquationMatchers
{
    public static readonly Regex matchesOfNumberPlusNumber = new Regex(
        $@"{MathCalculator.numberSubPatternWithOptionalNegative}({MathCalculator.escapedExponentiationSign}{MathCalculator.numberSubPatternWithOptionalNegative})+"
    );

    public static readonly Regex bracketedOprhanedNumberPattern = new Regex(
        @$"(?<!ABS)\(\{MathCalculator.numberSubPatternWithOptionalNegative}\)"
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
            + MathCalculator.numberSubPattern
            + MathCalculator.allOperatorsEscaped
            + MathCalculator.numberSubPattern
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
        // TODO: Unit test this!
        // Get match
        input = singleNumberAbsolutePattern.Match(input).Value.ToUpper();
        //Remove opening bracket and abs
        input = ReplacerUtility.RemoveOnlyFirstInstanceOfSubstring(input, "ABS(");
        // Remove closing bracket
        input = ReplacerUtility.RemoveOnlyLastInstanceOfSubstring(input, ")");
        return input;
    }

    public static string ExtractSingleNumberPositiveOrNegative(string input)
    {
        // TODO: unit test!
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
}
