namespace Calculator
{
    public static class CalculateSingleNumberUnaryMathsFunctions
    {
        public static string CalculateSingleNumberAbsolutes(string input)
        { // TODO: UNIT TEST
            while (BasicEquationMatchers.IsMatchOfSingleNumberAbsolute(input))
            {
                input = MathCalculator.CalculateFirstInstanceOfSingleNumberAbsolute(input);
                Console.WriteLine(input);
            }

            return input;
        }

        public static string CalculateSingleNumberSquareRoots(string input)
        { // TODO: UNIT TEST
            while (BasicEquationMatchers.IsMatchOfSingleNumberSquareRoot(input))
            {
                input = MathCalculator.CalculateFirstInstanceOfSingleNumberSquareRoot(input);
                Console.WriteLine(input);
            }
            return input;
        }
    }
}
