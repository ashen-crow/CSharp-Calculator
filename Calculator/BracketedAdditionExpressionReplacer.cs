using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Calculator
{
    public static class BracketedAdditionExpressionReplacer
    {
        public static readonly Regex bracketedAnyOperatorEquation = CreateBracketedEquationPattern(
            MathCalculator.allOperatorsEscaped
        );
        public static readonly Regex bracketedNumberPlusNumberPattern =
            CreateBracketedEquationPattern(MathCalculator.escapedPlusSign);
        public static readonly Regex bracketedNumberMinusNumberPattern =
            CreateBracketedEquationPattern(MathCalculator.escapedMinusSign);
        public static readonly Regex bracketedNumberMultipliedByNumberPattern =
            CreateBracketedEquationPattern(MathCalculator.escapedMultiplySign);
        public static readonly Regex bracketedNumberDividedByNumberPattern =
            CreateBracketedEquationPattern(MathCalculator.escapedDivideSign);

        private static Regex CreateBracketedEquationPattern(string escapedOperator)
        {
            return new Regex(
                $@".*\(.*{MathCalculator.numberSubPatternWithOptionalNegative}{escapedOperator}{MathCalculator.numberSubPatternWithOptionalNegative}.*\).*"
            );
        }

        public static string ReplaceFirstInstanceOfBracketedAdditionExpression(string input)
        { // TODO: Remove false negatives
            /////Match match = bracketedNumberPlusNumberPattern.Match(input);
            /////string matchStringified = match.Value;
            /////if (match.Success)
            /////{
            /////    // 1. Extract the subinstance of x+x
            /////    Regex subpattern =
            /////        BasicEquationMatchers.numberPlusNumberWithOptionalFirstNegativeNumberPattern;
            /////    Match submatch = subpattern.Match(matchStringified);
            /////    string submatchStringified = submatch.Value;
            /////    if (submatch.Success)
            /////    {
            /////        string equation = submatchStringified;
            /////        string[] numbers = equation.Split('+');
            /////        string result = MathsUtils
            /////            .AddStringifiedNumbers(numbers[0], numbers[1])
            /////            .ToString();
            /////        // Replace the match with the processed result
            /////        var resolvedBracketedExpression =
            /////            ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(
            /////                matchStringified,
            /////                submatchStringified,
            /////                result
            /////            );
            /////        input = ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(
            /////            input,
            /////            matchStringified,
            /////            resolvedBracketedExpression
            /////        );
            /////    }
            /////}
            /////return input;
            //
            return RenameMeImAParameterisedBracketsCalcFunc(
                input,
                bracketedNumberPlusNumberPattern,
                BasicEquationMatchers.numberPlusNumberWithOptionalFirstNegativeNumberPattern,
                "+",
                MathsUtils.AddStringifiedNumbers
            );
        }

        public static string ReplaceFirstInstanceOfBracketedMultiplicationExpression(string input)
        { // TODO: Remove false negatives
            ///////Match match = bracketedNumberMultipliedByNumberPattern.Match(input);
            ///////string matchStringified = match.Value;
            ///////if (match.Success)
            ///////{
            ///////    Regex subpattern = BasicEquationMatchers.numberMultipliedByNumberPattern;
            ///////    Match submatch = subpattern.Match(matchStringified);
            ///////    string submatchStringified = submatch.Value;
            ///////    if (submatch.Success)
            ///////    {
            ///////        string equation = submatchStringified;
            ///////        string[] numbers = equation.Split('*');
            ///////        string result = MathsUtils
            ///////            .MultiplyStringifiedNumbers(numbers[0], numbers[1])
            ///////            .ToString();
            ///////        var resolvedBracketedExpression =
            ///////            ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(
            ///////                matchStringified,
            ///////                submatchStringified,
            ///////                result
            ///////            );
            ///////        input = ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(
            ///////            input,
            ///////            matchStringified,
            ///////            resolvedBracketedExpression
            ///////        );
            ///////    }
            ///////}
            ///////return input;
            //

            return RenameMeImAParameterisedBracketsCalcFunc(
                input,
                bracketedNumberMultipliedByNumberPattern,
                BasicEquationMatchers.numberMultipliedByNumberPattern,
                "*",
                MathsUtils.MultiplyStringifiedNumbers
            );
        }

        public static string ReplaceFirstInstanceOfBracketedDivisionExpression(string input)
        {
            ////Match match = bracketedNumberDividedByNumberPattern.Match(input); // param 1
            ////string matchStringified = match.Value;
            ////if (match.Success)
            ////{
            ////    Regex subpattern = BasicEquationMatchers.numberDividedByNumberPattern; // param 2
            ////    Match submatch = subpattern.Match(matchStringified);
            ////    string submatchStringified = submatch.Value;
            ////    if (submatch.Success)
            ////    {
            ////        string equation = submatchStringified;
            ////        string[] numbers = equation.Split('/'); // param 3
            ////        string result = MathsUtils
            ////            .DivideStringifiedNumbers(numbers[0], numbers[1]) // Param 4 (sometimes another index is needed, but not always)
            ////            .ToString();
            ////        var resolvedBracketedExpression =
            ////            ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(
            ////                matchStringified,
            ////                submatchStringified,
            ////                result
            ////            );
            ////        input = ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(
            ////            input,
            ////            matchStringified,
            ////            resolvedBracketedExpression
            ////        );
            ////    }
            ////}
            ////return input;

            //

            return RenameMeImAParameterisedBracketsCalcFunc(
                input,
                bracketedNumberDividedByNumberPattern,
                BasicEquationMatchers.numberDividedByNumberPattern,
                "/",
                MathsUtils.DivideStringifiedNumbers
            );
        }

        private static string RenameMeImAParameterisedBracketsCalcFunc(
            // TODO: These params should probably just be a class instead
            string input,
            Regex pattern,
            Regex subPattern,
            string nonEscapedOperatorToSplit,
            Func<string, string, double> transformationFunction
        // TODO: first vs last: sometimes we want to transform the first match, sometimes the last
        // TODO: sometimes we want the last array index, sometimes the first
        )
        {
            Match match = pattern.Match(input);
            string matchStringified = match.Value;
            if (match.Success)
            {
                Match submatch = subPattern.Match(matchStringified);
                string submatchStringified = submatch.Value;
                if (submatch.Success)
                {
                    string equation = submatchStringified;
                    equation = FakeNegativesRemover.RemoveFakeNegativesFromFirstInstanceOfSubstring(
                        matchStringified,
                        equation
                    );
                    string[] numbers = equation.Split(nonEscapedOperatorToSplit);
                    string result = transformationFunction(numbers[0], numbers[1]).ToString();
                    var resolvedBracketedExpression =
                        ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(
                            matchStringified,
                            submatchStringified,
                            result
                        );
                    input = ReplacerUtility.ReplaceOnlyFirstInstanceOfSubstring(
                        input,
                        matchStringified,
                        resolvedBracketedExpression
                    );
                }
            }
            return input;
        }

        public static bool HasAnyMatchesOfBracketedEquation(string input)
        {
            return bracketedAnyOperatorEquation.IsMatch(input);
        }

        public static bool IsMatch(string input)
        {
            /*
                Should match:
                20/(2+3) yes
                20/(2+3)+5 yes
                20/(2+3+2)+5+10 yes
                20-3/(2+3+2)+5+10-5 yes
            */
            Regex pattern =
                new(
                    @".*"
                        + @"\(" // TODO: Extract to constant
                        + "" // Give me zero or one numbers or operators
                        + $"{BasicEquationMatchers.numberPlusNumberWithOptionalFirstNegativeNumberPattern}"
                        + @"\)" // TODO: Extract to constant
                        + @".*"
                );
            return pattern.IsMatch(input);
        }
    }
}
