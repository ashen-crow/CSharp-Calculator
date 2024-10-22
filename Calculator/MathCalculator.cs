using System.Text.RegularExpressions;

namespace Calculator;

public static class MathCalculator
{
    // TODO: add a pattern for the first negative number (^|\())-?\d+
    // TODO: add a pattern for the any negative numbern -?\d+

    public static readonly string startOfStringOrLineOrBracketedExpressionPattern = @"(^|\()";
    public static readonly string numberSubPattern = @"(\d+\.)*\d+";
    public static readonly string numberSubPatternWithOptionalNegative = @"-?(\d+\.)*\d+";
    public static readonly string numberSubPatternWithOptionalNegative_TheCorrectWay =
        // TODO: Implement this and remove brackets from captured values once implemented:
        // This version looks for a minus at the start of a string or a bracketed statement
        @"((^|\())-)?(\d+\.)*\d+";

    // (?:^|[\(])(-?\d+)

    public static readonly string escapedPlusSign = @"\+";
    public static readonly string escapedMinusSign = @"\-";
    public static readonly string escapedMultiplySign = @"\*";
    public static readonly string escapedDivideSign = @"\/";
    public static readonly string escapedModuloSign = @"\%";
    public static readonly string escapedExponentiationSign = @"\^";
    public static readonly string allOperatorsEscaped = @"[\+\-\*\/%\^]";

    public static bool MatchesAnyMathsExpression(string input)
    {
        return BasicEquationMatchers.IsMatchOfNumberPlusNumber(input)
            || BasicEquationMatchers.IsMatchOfNumberExponentiatedByNumber(input)
            || BasicEquationMatchers.IsMatchOfNumberMinusNumber(input)
            || BasicEquationMatchers.IsMatchOfNumberDividedByNumber(input)
            || BasicEquationMatchers.IsMatchOfNumberMultipliedByNumber(input)
            || BasicEquationMatchers.IsMatchOfNumberModuloNumber(input)
            || BasicEquationMatchers.IsMatchOfSingleNumberAbsolute(input)
            || BasicEquationMatchers.IsMatchOfSingleNumberSquareRoot(input)
            || BasicEquationMatchers.IsMatchOfAdvancedAbsolute(input)
            || BasicEquationMatchers.IsMatchOfBracketedOrphanedNumber(input);
        // TODO: Add more matchers for SQRT, ROUND etc
        // TODO: Implement other things such as brackets etc
    }

    public static string ProcessBidmasExceptBracketsIteratively(string input)
    {
        string result = input;
        while (MatchesAnyMathsExpression(result))
        {
            // B
            result = SimplifyAllBracketedOrphanedNumbers(result);
            result = CalculateBracketedExpressions(result);
            result = CalculateSingleNumberUnaryMathsFunctions.CalculateSingleNumberAbsolutes(
                result
            );
            result = CalculateBasicEquationAbsolutes(result);
            result = CalculateSingleNumberUnaryMathsFunctions.CalculateSingleNumberSquareRoots(
                result
            );
            //////////result = CalculateBasicEquationSquareRoots(result);
            // I
            result = CalculateIndices(result);
            // D
            result = CalculateDivisions(result);
            // result = CalculateModulations(result); // TODO: Implement modulo
            // M
            result = CalculateMultiplications(result);
            // Addition and Subtraction have equal precedence and are solved by order of appearance
            result = CalculateAdditionsAndSubtractionsByOrderOfAppearance(result);
        }
        return result;
    }

    public static string CalculateBracketedExpressions(string input)
    { // TODO: UNIT TEST
        while (BasicEquationMatchers.IsMatchOfBracketedExpression(input))
        {
            input = CalculateFirstInstanceOfBracketedExpression(input);
            Console.WriteLine(input);
        }
        return input;
    }

    public static string CalculateFirstInstanceOfBracketedExpression(string input)
    { // TODO: Unit test
        string firstMatch = BasicEquationMatchers.bracketedExpressionPattern.Match(input).Value;
        string result = ResolveBracketedExpression(firstMatch);
        return ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(input, firstMatch, result);
    }

    public static string CalculateBasicEquationAbsolutes(string input)
    {
        while (BasicEquationMatchers.IsMatchOfAdvancedAbsolute(input))
        {
            input = CalculateFirstInstanceOfBasicEquationAbsolute(input);
            Console.WriteLine(input);
        }
        return input;
    }

    public static string CalculateModulations(string input)
    {
        throw new NotImplementedException();
    }

    public static string ProcessBidmasExceptBrackets(string input)
    {
        input = CalculateIndices(input);
        input = CalculateMultiplications(input);
        input = CalculateDivisions(input);
        input = CalculateAdditionsAndSubtractionsByOrderOfAppearance(input);
        return input;
    }

    public static string SimplifyAllBracketedOrphanedNumbers(string input)
    {
        while (BasicEquationMatchers.IsMatchOfBracketedOrphanedNumber(input))
        {
            input = ReplaceFirstInstaceOfBracketedOrphanedNumber(input);
        }
        return input;
    }

    public static string CalculateAdditionsAndSubtractionsByOrderOfAppearance(string input)
    {
        // Additions and subtractions apparently have equal precedence
        //and are resolved by order of appearance
        input = ReplacerUtility.FlattenRepeatedPlusSigns(input);

        // TODO: enable negative numbers here, or simply sanitise the ++, --, -+, +-
        var basicAdditionPattern = new Regex(
            $"{numberSubPatternWithOptionalNegative}{escapedPlusSign}{numberSubPattern}"
        );
        var basicSubtractionPattern = new Regex(
            $"{numberSubPatternWithOptionalNegative}{escapedMinusSign}{numberSubPattern}"
        );

        while (basicAdditionPattern.IsMatch(input) || basicSubtractionPattern.IsMatch(input))
        {
            var additionMatch = basicAdditionPattern.Match(input);
            var subtractionMatch = basicSubtractionPattern.Match(input);
            var indexOfFirstAddition = basicAdditionPattern.IsMatch(input)
                ? additionMatch.Index
                : int.MaxValue;
            var indexOfFirstSubtraction = basicSubtractionPattern.IsMatch(input)
                ? basicSubtractionPattern.Match(input).Index
                : int.MaxValue;
            if (indexOfFirstAddition < indexOfFirstSubtraction)
            {
                var x = CalculateFirstInstanceOfNumberPlusNumberIncludingNegatives(
                    additionMatch.Value
                );
                input = ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(
                    input,
                    additionMatch.Value,
                    x
                );
            }
            else if (indexOfFirstSubtraction < indexOfFirstAddition)
            {
                var x = CalculateFirstInstanceOfNumberMinusNumberIncludingNegatives(
                    subtractionMatch.Value
                );
                input = ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(
                    input,
                    subtractionMatch.Value,
                    x
                );
            }
            else
            {
                throw new InvalidDataException(
                    "Cannot have simultaneously precedent plus and minus expressions!"
                );
            }
        }
        return input;
    }

    public static string CalculateSubtractionsAllowsForNegatives(string input)
    {
        while (BasicEquationMatchers.IsMatchOfNumberMinusNumberAllowsNegatives(input))
        {
            input = CalculateFirstInstanceOfNumberMinusNumberIncludingNegatives(input);
            Console.WriteLine(input);
        }
        return input;
    }

    public static string CalculateMultiplications(string input)
    {
        while (BasicEquationMatchers.IsMatchOfNumberMultipliedByNumber(input))
        {
            input = CalculateFirstInstanceOfNumberMultipliedByNumber(input);
            Console.WriteLine(input);
        }
        return input;
    }

    public static string CalculateDivisions(string input)
    {
        while (BasicEquationMatchers.IsMatchOfNumberDividedByNumber(input))
        {
            input = CalculateFirstInstanceOfNumberDividedByNumber(input);
            Console.WriteLine(input);
        }
        return input;
    }

    public static string CalculateIndices(string input)
    {
        while (BasicEquationMatchers.IsMatchOfNumberExponentiatedByNumber(input))
        {
            input = CalculateFirstInstanceOfNumberExponentiatedByNumberCorrectly(input);
            Console.WriteLine(input);
        }
        return input;
    }

    public static string CalculateFirstInstanceOfNumberMultipliedByNumber(string input)
    {
        input = input.ToUpper();
        input = ReplacerUtility.RemoveAllSpaces(input);
        var firstMatchOfNumberMultipliedByNumber = BasicEquationMatchers
            .numberMultipliedByNumberPattern.Match(input)
            .Value;
        Console.WriteLine(
            "Found first match of number * number: " + firstMatchOfNumberMultipliedByNumber
        );
        string[] numbers = firstMatchOfNumberMultipliedByNumber.Split('*');
        double sum = MathsUtils.MultiplyStringifiedNumbers(numbers[0], numbers[1]);
        input = input.Replace(firstMatchOfNumberMultipliedByNumber, sum.ToString());
        return input;
    }

    public static string CalculateFirstInstanceOfNumberDividedByNumber(string input)
    {
        input = input.ToUpper();
        input = ReplacerUtility.RemoveAllSpaces(input);
        var firstMatchOfNumberDividedByNumber = BasicEquationMatchers
            .numberDividedByNumberPattern.Match(input)
            .Value;
        Console.WriteLine(
            "Found first match of number / number: " + firstMatchOfNumberDividedByNumber
        );
        string[] numbers = firstMatchOfNumberDividedByNumber.Split('/');
        double sum = MathsUtils.DivideStringifiedNumbers(numbers[0], numbers[1]);
        input = input.Replace(firstMatchOfNumberDividedByNumber, sum.ToString());
        return input;
    }

    public static string CalculateFirstInstanceOfNumberModuloNumber(string input)
    {
        throw new NotImplementedException();
    }

    public static string CalculateFirstInstanceOfNumberExponentiatedByNumberCorrectly(string input)
    {
        input = input.ToUpper();
        input = ReplacerUtility.RemoveAllSpaces(input);
        const char symbol = '^';
        var matchesOfNumberExponentiatedByNumber =
            BasicEquationMatchers.numberexponentiatedByNumberPattern.Match(input);
        var firstMatchOfNumberExponentiatedByNumber = matchesOfNumberExponentiatedByNumber.Value;
        Console.WriteLine(
            $"Found last match of number {symbol} number: "
                + firstMatchOfNumberExponentiatedByNumber
        );
        string matchWithFakeNegativesRemoved =
            FakeNegativesRemover.RemoveFakeNegativesFromFirstInstanceOfSubstring(
                input,
                firstMatchOfNumberExponentiatedByNumber!
            )!;
        string[] numbers = matchWithFakeNegativesRemoved.Split(symbol);
        string number1 = numbers[numbers.Length - 2];
        string number2 = numbers[numbers.Length - 1];
        double result = MathsUtils.PowOfStringifiedNumbers(number1, number2);
        var substringToReplace = $"{number1}^{number2}";
        input = ReplacerUtility.ReplaceOnlyLastInstanceOfSubstring(
            input,
            substringToReplace,
            result.ToString()
        );
        return input;
    }

    public static string CalculateFirstInstanceOfSingleNumberAbsolute(string input)
    {
        string replacedInput = input;
        if (BasicEquationMatchers.IsMatchOfSingleNumberAbsolute(input))
        {
            const string fnName = "ABS";
            Regex pattern = BasicEquationMatchers.singleNumberAbsolutePattern;
            var capturedInput = BasicEquationMatchers.ExtractSingleNumberFromAbsolute(input);
            var result = MathsUtils.AbsOfStringifiedNumber(capturedInput).ToString();
            Console.WriteLine($"Calculated {fnName} string: {input} as {result}");
            replacedInput = pattern.Replace(input, result); // TODO: Add regex replacement to ReplacerUtility
            Console.WriteLine($"Replaced input: {replacedInput}");
        }
        return replacedInput;
    }

    public static string CalculateFirstInstanceOfSingleNumberSquareRoot(string input)
    {
        string replacedInput = input;
        if (BasicEquationMatchers.IsMatchOfSingleNumberSquareRoot(input))
        {
            const string fnName = "SQRT";
            var pattern = BasicEquationMatchers.singleNumberSquareRootPattern;
            var capturedInput = BasicEquationMatchers.ExtractSingleNumberFromSquareRoot(input);
            var result = MathsUtils.SquareRootOfStringifiedNumber(capturedInput).ToString();
            Console.WriteLine($"Calculated {fnName} string: {input} as {result}");
            replacedInput = pattern.Replace(input, result); // TODO: Add regex replacement to ReplacerUtility
            Console.WriteLine($"Replaced input: {replacedInput}");
        }
        return replacedInput;
    }

    public static string CalculateFirstInstanceOfBasicEquationAbsolute(string input)
    {
        string result = input;
        if (BasicEquationMatchers.IsMatchOfAdvancedAbsolute(result))
        {
            result = ReplacerUtility.RemoveOnlyLastInstanceOfSubstring(result, ")");
            result = ReplacerUtility.RemoveOnlyFirstInstanceOfSubstring(result, "ABS(");
            result = ProcessBidmasExceptBracketsIteratively(result);
        }
        return result;
    }

    public static string CalculateFirstInstanceOfNumberPlusNumberIncludingNegatives(string input)
    {
        // (^\-?(\d+))|(\(\-?\d+)
        // -20 (-20+7)
        input = input.ToUpper();
        input = ReplacerUtility.RemoveAllSpaces(input);
        input = input.Replace("--", "+");
        input = ReplacerUtility.FlattenRepeatedPlusSigns(input);
        input = input.Replace("+-", "-");
        input = input.Replace("+-", "-");
        var numberPlusNumberWithOptionalFirstNegativeNumberPattern =
            BasicEquationMatchers.numberPlusNumberWithOptionalFirstNegativeNumberPattern;
        var firstMatchOfNumberPlusNumber = numberPlusNumberWithOptionalFirstNegativeNumberPattern
            .Match(input)
            .Value;
        firstMatchOfNumberPlusNumber = ReplacerUtility.RemoveOutermostBrackets(
            firstMatchOfNumberPlusNumber
        );
        Console.WriteLine("Found first match of number + number: " + firstMatchOfNumberPlusNumber);
        string[] numbers = firstMatchOfNumberPlusNumber.Split('+');
        double sum = MathsUtils.AddStringifiedNumbers(numbers[0], numbers[1]);
        input = input.Replace(firstMatchOfNumberPlusNumber, sum.ToString());
        return input;
    }

    public static string CalculateFirstInstanceOfNumberMinusNumberIncludingNegatives(string input)
    {
        input = ReplacerUtility.RemoveAllSpaces(input);
        input = input.Replace("--", "+");
        input = ReplacerUtility.FlattenRepeatedPlusSigns(input);
        input = input.Replace("+-", "-");
        input = input.Replace("+-", "-");
        var firstMatchOfNumberMinusNumber = BasicEquationMatchers
            .numberMinusNumberPattern.Match(input)
            .Value;
        firstMatchOfNumberMinusNumber = ReplacerUtility.RemoveOutermostBrackets(
            firstMatchOfNumberMinusNumber
        );
        string firstNumber = BasicEquationMatchers.ExtractSingleNumberPositiveOrNegative(
            firstMatchOfNumberMinusNumber
        );
        var firstMatchSplitByMinusSigns = firstMatchOfNumberMinusNumber.Split('-');
        string secondNumber = firstMatchSplitByMinusSigns[^1].ToString();
        Console.WriteLine("Found first match of number - number: " + firstMatchOfNumberMinusNumber);
        double sum = MathsUtils.SubtractStringifiedNumbers(firstNumber, secondNumber);
        input = input.Replace(firstMatchOfNumberMinusNumber, sum.ToString());
        return input;
    }

    public static string ReplaceFirstInstaceOfBracketedOrphanedNumber(string input)
    {
        if (BasicEquationMatchers.IsMatchOfBracketedOrphanedNumber(input))
        {
            string firstMatch = BasicEquationMatchers
                .bracketedOrphanedNumberPattern.Match(input)
                .Value;
            string result = ReplacerUtility.RemoveOutermostBrackets(firstMatch);
            input = ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(input, firstMatch, result);
            //input = ReplacerUtility.RemoveOutermostBrackets(firstMatch);
        }
        return input;
    }

    public static string ResolveBracketedExpression(string input)
    {
        input = ReplacerUtility.RemoveAllSpaces(input);
        input = input.Replace("--", "+");
        input = ReplacerUtility.FlattenRepeatedPlusSigns(input);
        input = input.Replace("+-", "-");
        input = input.Replace("+-", "-");
        input = ReplacerUtility.RemoveOutermostBrackets(input);
        input = ProcessBidmasExceptBracketsIteratively(input);
        return input;
    }

    ///public static string CalculateBracketedExpressions_V2(string input) {
    ///    // If is match of bracketed indices:
    ///    while(new Regex($@"\({numberSubPatternWithOptionalNegative}({allOperatorsEscaped}+{numberSubPatternWithOptionalNegative})+\)").IsMatch(input)) {
    ///        //input = CalculateFirstInstanceOfNumberExponentiatedByNumberCorrectly(input);
    ///        //input = CalculateFirstInstanceOfNumberDividedByNumber(input);
    ///        //input = calcfir
    ///    }
    ///    // If is match of bracketed division:
    ///    // If is match of bracketed multiplication:
    ///    // If is match of bracketed addition/subtraction:
    ///    return input
    ///}
}
