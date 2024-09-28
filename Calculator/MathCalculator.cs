using System.Text.RegularExpressions;

namespace Calculator;

public static class MathCalculator
{
    public static readonly string numberSubPattern = @"([0-9]+\.)*[0-9]+";
    public static readonly string escapedPlusSign = @"\+";
    public static readonly string escapedMinusSign = @"\-";
    public static readonly string escapedMultiplySign = @"\*";
    public static readonly string escapedDivideSign = @"\/";
    public static readonly string escapedModuloSign = @"\%";
    public static readonly string escapedExponentiationSign = @"\^";
    public static readonly string allOperatorsEscaped = @"[\+\-\*\/%]";

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
        throw new NotImplementedException();
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
}
