using System.Runtime.InteropServices;
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

    public static readonly Regex firstMatchOfNumberMultipliedByNumber = CreateBasicEquationPattern(
        MathCalculator.escapedMultiplySign
    );

    public static readonly Regex numberPlusNumberWithOptionalFirstNegativeNumberPattern =
        CreateBasicEquationPattern(MathCalculator.escapedPlusSign);

    public static readonly Regex numberexponentiatedByNumberPattern = new Regex(
        $@"{MathCalculator.numberSubPatternWithOptionalNegative}({MathCalculator.escapedExponentiationSign}{MathCalculator.numberSubPatternWithOptionalNegative})+"
    );

    public static readonly Regex numberDividedByNumberPattern = CreateBasicEquationPattern(
        MathCalculator.escapedDivideSign
    );

    public static readonly Regex singleNumberAbsolutePattern =
        CreateSingleNumberUnaryMathsFunctionByNameCaseInsensitive("ABS");
    public static readonly Regex singleNumberSquareRootPattern =
        CreateSingleNumberUnaryMathsFunctionByNameCaseInsensitive("SQRT");

    public static Regex CreateSingleNumberUnaryMathsFunctionByNameCaseInsensitive(
        string functionNameShortName
    )
    { // TODO: UNIT TEST
        return new Regex(
            $@"{functionNameShortName}\("
                + MathCalculator.numberSubPatternWithOptionalNegative
                + @"\)",
            RegexOptions.IgnoreCase
        );
    }

    public static readonly Regex numberMinusNumberPattern = CreateBasicEquationPattern(
        MathCalculator.escapedMinusSign
    );

    public static readonly Regex BasicEquationWithinAbsPattern =
        CreateBasicEquationWithinUnaryMathsFunctionByNameCaseInsensitive("ABS");

    public static Regex CreateBasicEquationWithinUnaryMathsFunctionByNameCaseInsensitive(
        string functionNameShortName
    )
    {
        // TODO: UNIT TEST
        return new Regex(
            $@"{functionNameShortName}\("
                + MathCalculator.numberSubPatternWithOptionalNegative
                + MathCalculator.allOperatorsEscaped
                + MathCalculator.numberSubPatternWithOptionalNegative
                + @"\)",
            RegexOptions.IgnoreCase
        );
    }

    public static readonly Regex bracketedExpressionPattern =
        CreateBasicEquationWithinUnaryMathsFunctionByNameCaseInsensitive(string.Empty);

    public static Regex CreateBasicEquationPattern(string escapedOperator)
    { // TODO: UNIT TEST
        if (!escapedOperator.StartsWith('\\'))
        {
            throw new InvalidDataException("The operator must be escaped.");
        }
        return new Regex(
            $@"{MathCalculator.numberSubPatternWithOptionalNegative}{escapedOperator}{MathCalculator.numberSubPatternWithOptionalNegative}"
        );
    }

    public static bool IsMatchOfNumberPlusNumber(string input)
    {
        var pattern = CreateBasicEquationPattern(MathCalculator.escapedPlusSign);
        return pattern.IsMatch(input);
    }

    public static bool IsMatchOfNumberMinusNumber(string input)
    {
        return numberMinusNumberPattern.IsMatch(input);
    }

    public static bool IsMatchOfNumberMinusNumberAllowsNegatives(string input)
    {
        return numberMinusNumberPattern.IsMatch(input);
    }

    public static bool IsMatchOfNumberMultipliedByNumber(string input)
    {
        return firstMatchOfNumberMultipliedByNumber.IsMatch(input);
    }

    public static bool IsMatchOfNumberDividedByNumber(string input)
    {
        return numberDividedByNumberPattern.IsMatch(input);
    }

    public static bool IsMatchOfNumberModuloNumber(string input)
    {
        var pattern = CreateBasicEquationPattern(MathCalculator.escapedModuloSign);
        return pattern.IsMatch(input);
    }

    public static string ExtractSingleNumberFromAbsolute(string input)
    {
        return ExtractSingleNumberFromUnaryMathsFunctionByPattern(
            input,
            singleNumberAbsolutePattern
        );
    }

    public static string ExtractSingleNumberFromSquareRoot(string input)
    {
        return ExtractSingleNumberFromUnaryMathsFunctionByPattern(
            input,
            singleNumberSquareRootPattern
        );
    }

    public static string ExtractSingleNumberFromUnaryMathsFunctionByPattern(
        string input,
        Regex pattern
    )
    { // TODO: UNIT TEST
        input = pattern.Match(input).Value.ToUpper();
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
        return BasicEquationWithinAbsPattern.IsMatch(input);
    }

    public static bool IsMatchOfBracketedOrphanedNumber(string input)
    {
        return bracketedOrphanedNumberPattern.IsMatch(input);
    }

    public static bool IsMatchOfBracketedExpression(string result)
    {
        return bracketedExpressionPattern.IsMatch(result);
    }

    // ABS, SQRT, CEIL, FLOOR, TRUNC etc

    public static bool IsMatchOfSingleNumberAbsolute(string input)
    {
        return singleNumberAbsolutePattern.IsMatch(input);
    }

    public static bool IsMatchOfSingleNumberSquareRoot(string input)
    {
        return singleNumberSquareRootPattern.IsMatch(input);
    }
}
