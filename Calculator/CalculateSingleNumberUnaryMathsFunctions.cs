namespace Calculator
{
    public static class CalculateSingleNumberUnaryMathsFunctions
    {
        public static string CalculateSingleNumberAbsolutes(string input)
        {
            while (BasicEquationMatchers.IsMatchOfSingleNumberAbsolute(input))
            {
                input = MathCalculator.CalculateFirstInstanceOfSingleNumberAbsolute(input);
                Console.WriteLine(input);
            }

            return input;
        }

        public static string CalculateSingleNumberSquareRoots(string input)
        {
            while (BasicEquationMatchers.IsMatchOfSingleNumberSquareRoot(input))
            {
                input = MathCalculator.CalculateFirstInstanceOfSingleNumberSquareRoot(input);
                Console.WriteLine(input);
            }
            return input;
        }
    }
}
