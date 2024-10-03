namespace Calculator;

static class MathsFuncs
{
    public static double AddStringifiedNumbers(string a, string b)
    {
        return Add(double.Parse(a), double.Parse(b));
    }

    static double Add(double a, double b)
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
}
