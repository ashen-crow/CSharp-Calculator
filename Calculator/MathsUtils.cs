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

    // TODO: UNIT TEST THE BELOW:

    public static double Round(double a)
    { // TODO: UNIT TEST
        return Math.Round(a);
    }

    public static double RoundStringifiedNumber(string a)
    { // TODO: UNIT TEST
        return Round(double.Parse(a));
    }

    public static double Sqrt(double a)
    { // TODO: UNIT TEST
        return Math.Sqrt(a);
    }

    public static double SqrtOfStringifiedNumber(string a)
    { // TODO: UNIT TEST
        return Sqrt(double.Parse(a));
    }

    public static double Ceil(double a)
    { // TODO: UNIT TEST
        return Math.Ceiling(a);
    }

    public static double CeilOfStringifiedNumber(string a)
    { // TODO: UNIT TEST
        return Ceil(double.Parse(a));
    }

    public static double Floor(double a)
    { // TODO: UNIT TEST
        return Math.Floor(a);
    }

    public static double FloorOfStringifiedNumber(string a)
    { // TODO: UNIT TEST
        return Floor(double.Parse(a));
    }

    public static double Truncate(double a)
    { // TODO: UNIT TEST
        return Math.Truncate(a);
    }

    public static double TruncateOfStringifiedNumber(string a)
    { // TODO: UNIT TEST
        return Truncate(double.Parse(a));
    }

    public static double Modulo(double a, double b)
    { // TODO: UNIT TEST
        return a % b;
    }

    public static double ModuloOfStringifiedNumber(string a, string b)
    { // TODO: UNIT TEST
        return Modulo(double.Parse(a), double.Parse(b));
    }

    public static double SquareRoot(double a)
    { // TODO: UNIT TEST
        return Math.Sqrt(a);
    }

    public static double SquareRootOfStringifiedNumber(string a)
    { // TODO: UNIT TEST
        return SquareRoot(double.Parse(a));
    }
}
