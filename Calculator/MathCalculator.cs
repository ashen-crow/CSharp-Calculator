
using System.Text.RegularExpressions;

namespace Calculator;

// A number looks like 324,203.04


public static class MathCalculator
{
    public static string FindFirstDeepestInstanceOfUnaryMathFunction(string input)
    {
        // 0. Remove casing issues
        input = input.ToUpper();
        // 1. Find deepest instance of:
        // ((ABS)|(ROUND)|(FLOOR)|(CEIL)){0,1}\(-{0,1}[0-9]{1,3}\)
        Regex pattern = new(@"((ABS)|(ROUND)|(FLOOR)|(CEIL)){0,1}\(-{0,1}[0-9]{1,3}\)");


        return input;
    }

    public static string ExtractFirstInstanceOfNumberPlusNumber(string input)
    {
        input = input.ToUpper();
        Regex pattern = new(@"-{0,1}[0-9]{1,3}\+{1}-{0,1}[0-9]{1,3}");
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

    private static string CalculateSubtractions(string input)
    {
        throw new NotImplementedException();
    }

    private static string CalculateAdditions(string input)
    {
        throw new NotImplementedException();
    }

    private static string CalculateDivisions(string input)
    {
        throw new NotImplementedException();
    }

    private static string CalculateMultiplications(string input)
    {
        throw new NotImplementedException();
    }

    private static string CalculateIndices(string input)
    {
        throw new NotImplementedException();
    }

    public static string PLAN(string input)
    {
        input = input.ToUpper();
        input = input.Replace(" ", "");
        // A number looks like 324,203.04 or 24,324,203.04
        string allOperatorsEscaped = @"[\+\-\*\/%]";
        string escapedPlusSign = @"\+";
        string numberSubPattern = @"([0-9]+\.)*[0-9]+";

        // BIDMAS

        // 1. Find deepest instance of number + number:
        var firstMatchOfNumberPlusNumber = new Regex($@"{numberSubPattern}{escapedPlusSign}{numberSubPattern}").Match(input);
        Console.WriteLine("Found first match of number + number: " + firstMatchOfNumberPlusNumber.Value);
        // Grab the numbers:
        string[] numbers = firstMatchOfNumberPlusNumber.Value.Split('+');
        double number1 = double.Parse(numbers[0]);
        double number2 = double.Parse(numbers[1]);
        var sum = number1 + number2;

        input = input.Replace(firstMatchOfNumberPlusNumber.Value, sum.ToString());
        return input;
    }
}