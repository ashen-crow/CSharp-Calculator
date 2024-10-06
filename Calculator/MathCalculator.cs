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
    public static readonly string allOperatorsEscaped = @"[\+\-\*\/%]";

    public static bool MatchesAnyMathsExpression(string input)
    {
        return BasicEquationMatchers.IsMatchOfNumberPlusNumber(input)
            || BasicEquationMatchers.IsMatchOfNumberMinusNumber(input)
            || BasicEquationMatchers.IsMatchOfNumberDividedByNumber(input)
            || BasicEquationMatchers.IsMatchOfNumberMultipliedByNumber(input)
            || BasicEquationMatchers.IsMatchOfNumberModuloNumber(input)
            || BasicEquationMatchers.IsMatchOfSingleNumberAbsolute(input)
            || BasicEquationMatchers.IsMatchOfAdvancedAbsolute(input);
        // TODO: Implement other things such as brackets etc
    }

    public static string ProcessBidmasExceptBracketsIteratively(string input)
    {
        string result = input;
        while (MatchesAnyMathsExpression(result))
        {
            // B
            //result = CalculateBrackets(result); // TODO: Implement brackets
            result = CalculateSingleNumberAbsolutes(result);
            result = CalculateBasicEquationAbsolutes(result);
            // I
            result = CalculateIndices(result);
            // D
            result = CalculateDivisions(result);
            // result = CalculateModulations(result); // TODO: Implement modulo
            // M
            result = CalculateMultiplications(result);
            // Addition and Subtraction have equal precedence and are solved by order of appearance
            //// A
            //result = CalculateAdditions(result);
            //// S
            //result = CalculateSubtractions(result);
            result = CalculateAdditionsAndSubtractionsByOrderOfAppearance(result);
        }
        return result;
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

    public static string CalculateAdditionsAndSubtractionsByOrderOfAppearance(string input)
    {
        // Additions and subtractions apparently have equal precedence
        //and are resoilved by order of appearance
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
        return CalculateIndicesCorrectly(input);
    }

    public static string CalculateIndicesCorrectly(string input)
    {
        while (BasicEquationMatchers.IsMatchOfNumberExponentiatedByNumber(input))
        {
            input = CalculateFirstInstanceOfNumberExponentiatedByNumberCorrectly(input);
            Console.WriteLine(input);
        }
        return input;
    }

    public static string CalculateSingleNumberAbsolutes(string input)
    {
        while (BasicEquationMatchers.IsMatchOfSingleNumberAbsolute(input))
        {
            input = CalculateFirstInstanceOfSingleNumberAbsolute(input);
            Console.WriteLine(input);
        }

        return input;
    }

    public static string CalculateFirstInstanceOfNumberMultipliedByNumber(string input)
    {
        input = input.ToUpper();
        input = ReplacerUtility.RemoveAllSpaces(input);
        var firstMatchOfNumberMultipliedByNumber = BasicEquationMatchers
            .firstMatchOfNumberMultipliedByNumber.Match(input)
            .Value;
        Console.WriteLine(
            "Found first match of number * number: " + firstMatchOfNumberMultipliedByNumber
        );
        string[] numbers = firstMatchOfNumberMultipliedByNumber.Split('*');
        double sum = MathsFuncs.MultiplyStringifiedNumbers(numbers[0], numbers[1]);
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
        double sum = MathsFuncs.DivideStringifiedNumbers(numbers[0], numbers[1]);
        input = input.Replace(firstMatchOfNumberDividedByNumber, sum.ToString());
        return input;
    }

    public static string CalculateFirstInstanceOfNumberModuloNumber(string input)
    {
        throw new NotImplementedException();
    }

    public static string CalculateFirstInstanceOfNumberExponentiatedByNumber(string input)
    {
        input = input.ToUpper();
        input = ReplacerUtility.RemoveAllSpaces(input);
        char symbol = '^';
        var matchesOfNumberPlusNumber = BasicEquationMatchers.matchesOfNumberPlusNumber.Matches(
            input
        );
        var firstMatchOfNumberPlusNumber = matchesOfNumberPlusNumber[^1].Value;
        Console.WriteLine(
            $"Found last match of number {symbol} number: " + firstMatchOfNumberPlusNumber
        );
        string[] numbers = firstMatchOfNumberPlusNumber.Split(symbol);
        double result = MathsFuncs.PowOfStringifiedNumbers(numbers[0], numbers[1]);
        input = ReplacerUtility.ReplaceOnlyLastInstanceOfSubstring(
            input,
            firstMatchOfNumberPlusNumber,
            result.ToString()
        );
        return input;
    }

    private static string CalculateFirstInstanceOfNumberExponentiatedByNumberCorrectly(string input)
    {
        input = input.ToUpper();
        input = ReplacerUtility.RemoveAllSpaces(input);
        char symbol = '^';
        var matchesOfNumberPlusNumber = new Regex(
            $@"{numberSubPattern}({escapedExponentiationSign}{numberSubPattern})+"
        ).Match(input);
        var firstMatchOfNumberPlusNumber = matchesOfNumberPlusNumber.Value;
        Console.WriteLine(
            $"Found last match of number {symbol} number: " + firstMatchOfNumberPlusNumber
        );
        string[] numbers = firstMatchOfNumberPlusNumber.Split(symbol);
        double number1 = double.Parse(numbers[numbers.Length - 2]);
        double number2 = double.Parse(numbers[numbers.Length - 1]);
        double result = Math.Pow(number1, number2);
        var toBeReplaced = $"{number1}^{number2}";
        input = ReplacerUtility.ReplaceOnlyLastInstanceOfSubstring(
            input,
            toBeReplaced,
            result.ToString()
        );
        return input;
    }

    public static string CalculateFirstInstanceOfNumberRootedByNumber(string input)
    {
        throw new NotImplementedException();
    }

    public static string CalculateFirstInstanceOfNumberFactorial(string input)
    {
        throw new NotImplementedException();
    }

    public static string CalculateFirstInstanceOfSingleNumberAbsolute(string input)
    {
        string replacedInput = input;
        if (BasicEquationMatchers.IsMatchOfSingleNumberAbsolute(input))
        {
            var capturedInput = BasicEquationMatchers.ExtractSingleNumberFromAbsolute(input);
            var parsedInput = new Regex(numberSubPatternWithOptionalNegative)
                .Match(capturedInput)
                .Value;
            var result = MathsFuncs.AbsOfStringifiedNumber(parsedInput).ToString();
            Console.WriteLine($"Calculated ABS string: {input} as {result}");
            replacedInput = BasicEquationMatchers.singleNumberAbsolutePattern.Replace(
                input,
                result
            ); // TODO: Add regex replacement to ReplacerUtility
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
        input = input.Replace("++", "+");
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
        double sum = MathsFuncs.AddStringifiedNumbers(numbers[0], numbers[1]);
        input = input.Replace(firstMatchOfNumberPlusNumber, sum.ToString());
        return input;
    }

    public static string CalculateFirstInstanceOfNumberMinusNumberIncludingNegatives(string input)
    {
        input = ReplacerUtility.RemoveAllSpaces(input);
        input = input.Replace("--", "+");
        input = input.Replace("++", "+");
        input = input.Replace("+-", "-");
        input = input.Replace("+-", "-");
        var firstMatchOfNumberMinusNumber = BasicEquationMatchers
            .numberMinusNumberAllowsNegativesPattern.Match(input)
            .Value;
        firstMatchOfNumberMinusNumber = ReplacerUtility.RemoveOutermostBrackets(
            firstMatchOfNumberMinusNumber
        );
        string firstNumber = BasicEquationMatchers.ExtractSingleNumberPositiveOrNegative(
            firstMatchOfNumberMinusNumber
        );
        var firstMatchSplitByMinusSigns = firstMatchOfNumberMinusNumber.Split('-');
        string secondNumber = firstMatchSplitByMinusSigns.Last().ToString();
        Console.WriteLine("Found first match of number - number: " + firstMatchOfNumberMinusNumber);
        double sum = MathsFuncs.SubtractStringifiedNumbers(firstNumber, secondNumber);
        input = input.Replace(firstMatchOfNumberMinusNumber, sum.ToString());
        return input;
    }

    // Find first match of bracketed number (7) but not ABS(7):
    public static string SimplifyBracketedOrphanedNumber(string input)
    {
        var pattern = new Regex(@$"(?<!ABS)\(\{numberSubPatternWithOptionalNegative}\)");
        if (pattern.IsMatch(input))
        {
            string firstMatch = pattern.Match(input).Value;
            input = ReplacerUtility.RemoveOutermostBrackets(firstMatch);
        }
        return input;
    }

    public static string ResolveBracketedExpression(string input)
    {
        input = ReplacerUtility.RemoveAllSpaces(input);
        input = input.Replace("--", "+");
        input = input.Replace("++", "+");
        input = input.Replace("+-", "-");
        input = input.Replace("+-", "-");
        input = ReplacerUtility.RemoveOutermostBrackets(input);
        input = ProcessBidmasExceptBracketsIteratively(input);
        return input;
    }
}
