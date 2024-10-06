namespace Calculator;

public static class ReplacerUtility
{
    // TODO: Implement replacing/removing by regex (it's strings only rn!)

    public static string ReplaceAllInstancesOfSubstring(
        string input,
        string substringToReplace,
        string replacement
    )
    {
        return input.Replace(substringToReplace, replacement);
    }

    public static string RemoveAllInstancesOfSubstring(string input, string substringToReplace)
    {
        return ReplaceAllInstancesOfSubstring(input, substringToReplace, string.Empty);
    }

    public static string RemoveOnlyFirstInstanceOfSubstring(string input, string substringToReplace)
    {
        return ReplaceOnlyFirstInstanceOfSubstring(input, substringToReplace, string.Empty);
    }

    public static string ReplaceOnlyFirstInstanceOfSubstring(
        string input,
        string substringToReplace,
        string replacement
    )
    {
        string result = input;
        int index = input.IndexOf(substringToReplace);

        if (index != -1)
        {
            // Replace the first occurrence
            result =
                input.Substring(0, index)
                + replacement
                + input.Substring(index + substringToReplace.Length);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Substring not found.");
        }
        return result;
    }

    public static string RemoveOnlyLastInstanceOfSubstring(string input, string substringToReplace)
    {
        return ReplaceOnlyLastInstanceOfSubstring(input, substringToReplace, string.Empty);
    }

    public static string ReplaceOnlyLastInstanceOfSubstring(
        string input,
        string substringToReplace,
        string replacement
    )
    {
        string result = input;
        int index = input.LastIndexOf(substringToReplace);

        if (index != -1)
        {
            // Replace the first occurrence
            result =
                input.Substring(0, index)
                + replacement
                + input.Substring(index + substringToReplace.Length);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Substring not found.");
        }
        return result;
    }

    public static string RemoveOutermostBrackets(string input)
    {
        input = RemoveOnlyFirstInstanceOfSubstring(input, "(");
        input = RemoveOnlyLastInstanceOfSubstring(input, ")");
        return input;
    }

    public static string RemoveAllSpaces(string input)
    {
        input = RemoveAllInstancesOfSubstring(input, " ");
        return input;
    }
}
