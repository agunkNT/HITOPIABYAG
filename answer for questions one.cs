using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<char, int> CalculateWeights(string s)
    {
        var weights = new Dictionary<char, int>();
        int weight = 1;

        foreach (char c in s)
        {
            if (!weights.ContainsKey(c))
            {
                weights[c] = weight;
            }
            else
            {
                weight++;
                weights[c] = weight;
            }
        }

        return weights;
    }

    static List<string> WeightedStrings(string s, List<int> queries)
    {
        var weights = CalculateWeights(s);
        var results = new List<string>();

        foreach (int query in queries)
        {
            if (weights.ContainsValue(query))
            {
                results.Add("Yes");
            }
            else
            {
                results.Add("No");
            }
        }

        return results;
    }

    static void Main()
    {
        string inputString = "abbcccd";
        List<int> inputQueries = new List<int> { 1, 3, 9, 8 };

        List<string> output = WeightedStrings(inputString, inputQueries);

        foreach (string result in output)
        {
            Console.WriteLine(result);
        }
    }
}
