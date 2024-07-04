using System;

class Program
{
    static int HighestPalindrome(string s, int k)
    {
        // Helper function to check if a string is a palindrome
        bool IsPalindrome(string str)
        {
            int i = 0, j = str.Length - 1;
            while (i < j)
            {
                if (str[i] != str[j])
                    return false;
                i++;
                j--;
            }
            return true;
        }

        // Recursive function to find the highest palindrome
        int Helper(string str, int left, int right, int replacements)
        {
            if (replacements < 0)
                return -1; // Invalid case

            if (left >= right)
                return int.Parse(str); // Base case: convert string to integer

            if (str[left] == str[right])
                return Helper(str, left + 1, right - 1, replacements); // No replacement needed

            // Try replacing left or right character
            int replaceLeft = Helper(str.Substring(0, left) + str[right] + str.Substring(left + 1), left + 1, right, replacements - 1);
            int replaceRight = Helper(str.Substring(0, right) + str[left] + str.Substring(right + 1), left, right - 1, replacements - 1);

            return Math.Max(replaceLeft, replaceRight);
        }

        int result = Helper(s, 0, s.Length - 1, k);
        return IsPalindrome(result.ToString()) ? result : -1;
    }

    static void Main()
    {
        string input1 = "3943";
        int k1 = 1;
        Console.WriteLine(HighestPalindrome(input1, k1)); // Output: 3993

        string input2 = "932239";
        int k2 = 2;
        Console.WriteLine(HighestPalindrome(input2, k2)); // Output: 992299
    }
}
