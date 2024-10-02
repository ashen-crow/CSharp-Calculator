using System.Text.RegularExpressions;

namespace Calculator;

public static class BasicEquationMatchers
{
    static readonly Regex singleNumberAbsolutePattern = new Regex(
        @"ABS\(" + MathCalculator.numberSubPatternWithOptionalNegative + @"\)",
        RegexOptions.IgnoreCase
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

    ///// TODO: Refactor this:
    ///public static bool IsMatchOfNumberDividedByNumberIncludesNegativeNumbers(string input)
    ///{
    ///    // TODO: Build a regex whose second operand has an optional negative sign
    ///
    ///    // Scenario: 3/4
    ///    var a = new Regex(
    ///        $@"{MathCalculator.numberSubPattern}{MathCalculator.escapedDivideSign}{MathCalculator.numberSubPattern}"
    ///    ).IsMatch(input);
    ///    // Scenario: -3/4
    ///    var b = new Regex(
    ///        $@"([\(\)]{MathCalculator.escapedMinusSign}){MathCalculator.numberSubPattern}{MathCalculator.escapedDivideSign}{MathCalculator.numberSubPattern}"
    ///    ).IsMatch(input);
    ///    // Scenario: 3/-4
    ///    // Scenario: -3/-4
    ///}

    public static bool IsMatchOfNumberMinusNumber(string input)
    {
        return new Regex(
            $@"{MathCalculator.numberSubPattern}{MathCalculator.escapedMinusSign}{MathCalculator.numberSubPattern}"
        ).IsMatch(input);
    }

    public static bool IsMatchOfNumberMultipliedByNumber(string input)
    {
        return new Regex(
            $@"{MathCalculator.numberSubPattern}{MathCalculator.escapedMultiplySign}{MathCalculator.numberSubPattern}"
        ).IsMatch(input);
    }

    public static bool IsMatchOfNumberDividedByNumber(string input)
    {
        return new Regex(
            $@"{MathCalculator.numberSubPattern}{MathCalculator.escapedDivideSign}{MathCalculator.numberSubPattern}"
        ).IsMatch(input);
    }

    public static bool IsMatchOfNumberModuloNumber(string input)
    {
        return new Regex(
            $@"{MathCalculator.numberSubPattern}{MathCalculator.escapedModuloSign}{MathCalculator.numberSubPattern}"
        ).IsMatch(input);
    }

    public static bool IsMatchOfSingleNumberAbsolute(string input)
    {
        //return new Regex(@"ABS\([\d\.]+\)"+MathCalculator.numberSubPatternWithOptionalNegative+"", RegexOptions.IgnoreCase).IsMatch(input);
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

    public static bool IsMatchOfNumberExponentiatedByNumber(string input)
    {
        return new Regex(
            $@"{MathCalculator.numberSubPattern}{MathCalculator.escapedExponentiationSign}{MathCalculator.numberSubPattern}"
        ).IsMatch(input);
    }

    public static bool IsMatchOfAdvancedAbsolute(string input)
    {
        return AdvancedAbsPattern.IsMatch(input);
    }
}
