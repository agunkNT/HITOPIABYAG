using System;
using System.Collections.Generic;

class Program
{
    static bool AreBracketsBalanced(string s)
    {
        var stack = new Stack<char>();
        var brackets = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        foreach (char c in s)
        {
            if (brackets.ContainsKey(c))
            {
                stack.Push(c);
            }
            else if (brackets.ContainsValue(c))
            {
                if (stack.Count == 0 || brackets[stack.Pop()] != c)
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    static void Main()
    {
        string input1 = "{ [ ( ) ] }";
        string input2 = "{ [ ( ] ) }";
        string input3 = "{ ( ( [ ] ) [ ] ) [ ] }";

        Console.WriteLine(AreBracketsBalanced(input1)); // Output: YES
        Console.WriteLine(AreBracketsBalanced(input2)); // Output: NO
        Console.WriteLine(AreBracketsBalanced(input3)); // Output: YES
    }
}
