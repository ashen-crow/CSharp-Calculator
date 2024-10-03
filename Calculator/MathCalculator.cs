using System.Text.RegularExpressions;

namespace Calculator;

public static class MathCalculator
{
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
            // A
            result = CalculateAdditions(result);
            // S
            result = CalculateSubtractions(result);
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

    public static string CalculateBrackets(string input)
    {
        // TODO: Implement
        throw new NotImplementedException();
    }

    public static string ProcessBidmasExceptBrackets(string input)
    {
        input = CalculateIndices(input);
        input = CalculateMultiplications(input);
        input = CalculateDivisions(input);
        input = CalculateAdditions(input);
        input = CalculateSubtractions(input);
        return input;
    }

    public static string CalculateAdditions(string input)
    {
        while (BasicEquationMatchers.IsMatchOfNumberPlusNumber(input))
        {
            input = CalculateFirstInstanceOfNumberPlusNumber(input);
            Console.WriteLine(input);
        }
        return input;
    }

    public static string CalculateSubtractions(string input)
    {
        while (BasicEquationMatchers.IsMatchOfNumberMinusNumber(input))
        {
            input = CalculateFirstInstanceOfNumberMinusNumber(input);
            Console.WriteLine(input);
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
        //while (BasicEquationMatchers.IsMatchOfNumberExponentiatedByNumber(input))
        //{
        //    input = CalculateFirstInstanceOfNumberExponentiatedByNumber(input);
        //    Console.WriteLine(input);
        //}
        //return input;
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
            System.Console.WriteLine(input);
        }

        return input;
    }

    public static string CalculateFirstInstanceOfNumberPlusNumber(string input)
    {
        input = input.ToUpper();
        input = input.Replace(" ", "");
        var firstMatchOfNumberPlusNumber = new Regex(
            $@"{numberSubPattern}{escapedPlusSign}{numberSubPattern}"
        ).Match(input);
        Console.WriteLine(
            "Found first match of number + number: " + firstMatchOfNumberPlusNumber.Value
        );
        string[] numbers = firstMatchOfNumberPlusNumber.Value.Split('+');
        double number1 = double.Parse(numbers[0]);
        double number2 = double.Parse(numbers[1]);
        double sum = number1 + number2;
        input = input.Replace(firstMatchOfNumberPlusNumber.Value, sum.ToString());
        return input;
    }

    public static string CalculateFirstInstanceOfNumberMinusNumber(string input)
    {
        // TODO: Implement allowing negative numbers here, as this is not currently allowed
        input = input.ToUpper();
        input = input.Replace(" ", "");
        var firstMatchOfNumberPlusNumber = new Regex(
            $@"{numberSubPattern}{escapedMinusSign}{numberSubPattern}"
        ).Match(input);
        Console.WriteLine(
            "Found first match of number - number: " + firstMatchOfNumberPlusNumber.Value
        );
        string[] numbers = firstMatchOfNumberPlusNumber.Value.Split('-');
        double number1 = double.Parse(numbers[0]);
        double number2 = double.Parse(numbers[1]);
        double sum = number1 - number2;
        input = input.Replace(firstMatchOfNumberPlusNumber.Value, sum.ToString());
        return input;
    }

    public static string CalculateFirstInstanceOfNumberMultipliedByNumber(string input)
    {
        input = input.ToUpper();
        input = input.Replace(" ", "");
        var firstMatchOfNumberPlusNumber = new Regex(
            $@"{numberSubPattern}{escapedMultiplySign}{numberSubPattern}"
        ).Match(input);
        Console.WriteLine(
            "Found first match of number * number: " + firstMatchOfNumberPlusNumber.Value
        );
        string[] numbers = firstMatchOfNumberPlusNumber.Value.Split('*');
        double number1 = double.Parse(numbers[0]);
        double number2 = double.Parse(numbers[1]);
        double sum = number1 * number2;
        input = input.Replace(firstMatchOfNumberPlusNumber.Value, sum.ToString());
        return input;
    }

    public static string CalculateFirstInstanceOfNumberDividedByNumber(string input)
    {
        input = input.ToUpper();
        input = input.Replace(" ", "");
        var firstMatchOfNumberPlusNumber = new Regex(
            $@"{numberSubPattern}{escapedDivideSign}{numberSubPattern}"
        ).Match(input);
        Console.WriteLine(
            "Found first match of number / number: " + firstMatchOfNumberPlusNumber.Value
        );
        string[] numbers = firstMatchOfNumberPlusNumber.Value.Split('/');
        double number1 = double.Parse(numbers[0]);
        double number2 = double.Parse(numbers[1]);
        double sum = number1 / number2;
        input = input.Replace(firstMatchOfNumberPlusNumber.Value, sum.ToString());
        return input;
    }

    public static string CalculateFirstInstanceOfNumberModuloNumber(string input)
    {
        throw new NotImplementedException();
    }

    public static string CalculateFirstInstanceOfNumberExponentiatedByNumber(string input)
    {
        input = input.ToUpper();
        input = input.Replace(" ", "");
        char symbol = '^';
        var matchesOfNumberPlusNumber = new Regex(
            $@"{numberSubPattern}({escapedExponentiationSign}{numberSubPattern})+"
        ).Matches(input);
        var firstMatchOfNumberPlusNumber = matchesOfNumberPlusNumber[^1].Value;
        Console.WriteLine(
            $"Found last match of number {symbol} number: " + firstMatchOfNumberPlusNumber
        );
        string[] numbers = firstMatchOfNumberPlusNumber.Split(symbol);
        double number1 = double.Parse(numbers[0]);
        double number2 = double.Parse(numbers[1]);
        double result = Math.Pow(number1, number2);
        input = ReplacerUtility.ReplaceOnlyLastInstanceOfSubstring(
            input,
            firstMatchOfNumberPlusNumber,
            result.ToString()
        );
        //input = input.Replace(firstMatchOfNumberPlusNumber.Value, result.ToString());
        return input;
    }

    private static string CalculateFirstInstanceOfNumberExponentiatedByNumberCorrectly(string input)
    {
        input = input.ToUpper();
        input = input.Replace(" ", "");
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
        //input = input.Replace(firstMatchOfNumberPlusNumber.Value, result.ToString());
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
            var parsedInput = new Regex(numberSubPatternWithOptionalNegative).Match(capturedInput);
            double number = double.Parse(parsedInput.Value);
            var result = Math.Abs(number);
            Console.WriteLine($"Calculated ABS string: {input} as {result}");
            ///////replacedInput = new Regex(numberSubPatternWithOptionalNegative).Replace(
            ///////    input,
            ///////    result.ToString()
            ///////);
            replacedInput = new Regex(
                @"ABS\(" + numberSubPatternWithOptionalNegative + @"\)",
                RegexOptions.IgnoreCase
            ).Replace(input, result.ToString());
            Console.WriteLine($"Replaced input: {replacedInput}");
        }
        return replacedInput;
    }

    public static string CalculateFirstInstanceOfBasicEquationAbsolute(string input)
    {
        ///var pattern = new Regex(
        ///    @"ABS\(" + numberSubPattern + allOperatorsEscaped + numberSubPattern + @"\)"
        ///);
        string result = input;
        if (BasicEquationMatchers.IsMatchOfAdvancedAbsolute(input))
        {
            var mutatedInput = ReplacerUtility.RemoveOnlyLastInstanceOfSubstring(input, ")");
            mutatedInput = ReplacerUtility.RemoveOnlyFirstInstanceOfSubstring(mutatedInput, "ABS(");
            result = ProcessBidmasExceptBrackets(mutatedInput); // TODO: Switch this to the version allowing brackets and iterative resolving ()
        }
        return result;
    }

    public static string CalculateFirstInstanceOfNumberPlusNumberIncludingNegatives(string input)
    {
        // (^\-?(\d+))|(\(\-?\d+)
        // -20 (-20+7)
        input = input.ToUpper();
        input = input.Replace(" ", "");
        input = input.Replace("--", "+");
        input = input.Replace("++", "+");
        input = input.Replace("+-", "-");
        input = input.Replace("+-", "-");
        var numberPlusNumberWithOptionalFirstNegativeNumberPattern = new Regex(
            startOfStringOrLineOrBracketedExpressionPattern
                + numberSubPatternWithOptionalNegative
                + allOperatorsEscaped
                + numberSubPattern
        );
        var firstMatchOfNumberPlusNumber = numberPlusNumberWithOptionalFirstNegativeNumberPattern
            .Match(input)
            .Value;
        //var firstMatchOfNumberPlusNumber = new Regex(
        //    $@"{numberSubPatternWithOptionalNegative}{escapedPlusSign}{numberSubPatternWithOptionalNegative}"
        //).Match(input);
        firstMatchOfNumberPlusNumber = ReplacerUtility.RemoveOnlyFirstInstanceOfSubstring(
            firstMatchOfNumberPlusNumber,
            "("
        );
        Console.WriteLine("Found first match of number + number: " + firstMatchOfNumberPlusNumber);
        string[] numbers = firstMatchOfNumberPlusNumber.Split('+');
        // double number1 = double.Parse(numbers[0]);
        // double number2 = double.Parse(numbers[1]);
        // double sum = number1 + number2;
        double sum = MathsFuncs.AddStringifiedNumbers(numbers[0], numbers[1]);
        input = input.Replace(firstMatchOfNumberPlusNumber, sum.ToString());
        return input;
    }

    public static string CalculateFirstInstanceOfNumberMinusNumberIncludingNegatives(string input)
    {
        input = input.Replace(" ", "");
        input = input.Replace("--", "+");
        input = input.Replace("++", "+");
        input = input.Replace("+-", "-");
        input = input.Replace("+-", "-");
        ///var numberMinusNumberWithOptionalFirstNegativeNumberPattern = new Regex(
        ///    startOfStringOrLineOrBracketedExpressionPattern
        ///        + numberSubPatternWithOptionalNegative
        ///        + allOperatorsEscaped
        ///        + numberSubPattern
        ///);
        var firstMatchOfNumberMinusNumber = BasicEquationMatchers
            .numberMinusNumberAllowsNegativesPattern.Match(input)
            .Value;
        //var firstMatchOfNumberPlusNumber = new Regex(
        //    $@"{numberSubPatternWithOptionalNegative}{escapedPlusSign}{numberSubPatternWithOptionalNegative}"
        //).Match(input);
        firstMatchOfNumberMinusNumber = ReplacerUtility.RemoveOnlyFirstInstanceOfSubstring(
            firstMatchOfNumberMinusNumber,
            "("
        );
        string firstNumber = new Regex(numberSubPatternWithOptionalNegative)
            .Match(firstMatchOfNumberMinusNumber)
            .Value;
        var firstMatchSplitByMinusSigns = firstMatchOfNumberMinusNumber.Split('-');
        string secondNumber = firstMatchSplitByMinusSigns.Last().ToString(); // TODO: FIX! THIS IS THE LINE! GET THE LAST INDEX
        Console.WriteLine("Found first match of number - number: " + firstMatchOfNumberMinusNumber);
        //string[] numbers = firstMatchOfNumberMinusNumber.Split('-');
        //string[] numbers_ = ;
        // double number1 = double.Parse(numbers[0]);
        // double number2 = double.Parse(numbers[1]);
        // double sum = number1 + number2;
        double sum = MathsFuncs.SubtractStringifiedNumbers(firstNumber, secondNumber);
        input = input.Replace(firstMatchOfNumberMinusNumber, sum.ToString());
        return input;
    }
}
