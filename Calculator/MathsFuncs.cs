namespace Calculator;

public static class MathsUtils
{
    public static double AddStringifiedNumbers(string a, string b)
    {
        return Add(double.Parse(a), double.Parse(b));
    }

    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static double SubtractStringifiedNumbers(string a, string b)
    {
        return Subtract(double.Parse(a), double.Parse(b));
    }

    public static double Abs(double a)
    {
        return Math.Abs(a);
    }

    public static double AbsOfStringifiedNumber(string a)
    {
        return Abs(double.Parse(a));
    }

    public static double Divide(double a, double b)
    {
        return a / b;
    }

    public static double DivideStringifiedNumbers(string a, string b)
    {
        return Divide(double.Parse(a), double.Parse(b));
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    public static double MultiplyStringifiedNumbers(string a, string b)
    {
        return Multiply(double.Parse(a), double.Parse(b));
    }

    public static double Pow(double a, double b)
    {
        return Math.Pow(a, b);
    }

    public static double PowOfStringifiedNumbers(string a, string b)
    {
        return Pow(double.Parse(a), double.Parse(b));
    }
}
