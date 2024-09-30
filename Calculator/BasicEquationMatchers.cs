using System.Text.RegularExpressions;

namespace Calculator;

public static class BasicEquationMatchers
{
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
        return new Regex(
            @"ABS\(" + MathCalculator.numberSubPatternWithOptionalNegative + @"\)",
            RegexOptions.IgnoreCase
        ).IsMatch(input);
    }
}
