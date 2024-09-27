
using System.Text.RegularExpressions;

namespace Calculator;

// A number looks like 324,203.04


public static class MathCalculator
{
    public static readonly string numberSubPattern = @"([0-9]+\.)*[0-9]+";
    public static readonly string escapedPlusSign = @"\+";
    public static readonly string escapedMinusSign = @"\-";
    public static readonly string escapedMultiplySign = @"\*";
    public static readonly string escapedDivideSign = @"\/";
    public static readonly string escapedModuloSign = @"\%";
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

    public static string CalculateSubtractions(string input)
    {
        while (IsMatchOfNumberMinusNumber(input))
        {
            input = CalculateFirstInstanceOfNumberMinusNumber(input);
            Console.WriteLine(input);
        }
        return input;
    }

    public static bool IsMatchOfNumberPlusNumber(string input)
    {
        return new Regex($@"{numberSubPattern}{escapedPlusSign}{numberSubPattern}").IsMatch(input);
    }

    public static bool IsMatchOfNumberMinusNumber(string input)
    {
        return new Regex($@"{numberSubPattern}{escapedMinusSign}{numberSubPattern}").IsMatch(input);
    }

    public static bool IsMatchOfNumberMultipliedByNumber(string input)
    {
        return new Regex($@"{numberSubPattern}{escapedMultiplySign}{numberSubPattern}").IsMatch(input);
    }

    public static bool IsMatchOfNumberDividedByNumber(string input)
    {
        return new Regex($@"{numberSubPattern}{escapedDivideSign}{numberSubPattern}").IsMatch(input);
    }

    public static bool IsMatchOfNumberModuloNumber(string input)
    {
        return new Regex($@"{numberSubPattern}{escapedModuloSign}{numberSubPattern}").IsMatch(input);
    }

    public static string CalculateAdditions(string input)
    {
        while (IsMatchOfNumberPlusNumber(input))
        {
            input = CalculateFirstInstanceOfNumberPlusNumber(input);
            Console.WriteLine(input);
        }
        return input;
    }

    public static string CalculateDivisions(string input)
    {
        while (IsMatchOfNumberDividedByNumber(input))
        {
            input = CalculateFirstInstanceOfNumberDividedByNumber(input);
            Console.WriteLine(input);
        }
        return input;
    }



    private static string CalculateMultiplications(string input)
    {
        throw new NotImplementedException();
    }

    private static string CalculateIndices(string input)
    {
        throw new NotImplementedException();
    }

    public static string CalculateFirstInstanceOfNumberPlusNumber(string input)
    {
        input = input.ToUpper();
        input = input.Replace(" ", "");
        var firstMatchOfNumberPlusNumber = new Regex($@"{numberSubPattern}{escapedPlusSign}{numberSubPattern}").Match(input);
        Console.WriteLine("Found first match of number + number: " + firstMatchOfNumberPlusNumber.Value);
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
        var firstMatchOfNumberPlusNumber = new Regex($@"{numberSubPattern}{escapedMinusSign}{numberSubPattern}").Match(input);
        Console.WriteLine("Found first match of number - number: " + firstMatchOfNumberPlusNumber.Value);
        string[] numbers = firstMatchOfNumberPlusNumber.Value.Split('-');
        double number1 = double.Parse(numbers[0]);
        double number2 = double.Parse(numbers[1]);
        double sum = number1 - number2;
        input = input.Replace(firstMatchOfNumberPlusNumber.Value, sum.ToString());
        return input;
    }

    public static string CalculateFirstInstanceOfNumberDividedByNumber(string input)
    {
        input = input.ToUpper();
        input = input.Replace(" ", "");
        var firstMatchOfNumberPlusNumber = new Regex($@"{numberSubPattern}{escapedDivideSign}{numberSubPattern}").Match(input);
        Console.WriteLine("Found first match of number / number: " + firstMatchOfNumberPlusNumber.Value);
        string[] numbers = firstMatchOfNumberPlusNumber.Value.Split('/');
        double number1 = double.Parse(numbers[0]);
        double number2 = double.Parse(numbers[1]);
        double sum = number1 / number2;
        input = input.Replace(firstMatchOfNumberPlusNumber.Value, sum.ToString());
        return input;
    }
}