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

    public static bool IsMatchOfNumberMinusNumberIncludesNegativeNumbers(string input)
    {
        throw new NotImplementedException();
    }

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
}
