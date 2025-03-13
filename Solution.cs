using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestGSI
{

    public class Solution
    {
        // Kamus
        public Dictionary<char, int> dictionary = new Dictionary<char, int>
        {
            {'A', 0}, {'B', 1}, {'C', 1}, {'D', 1}, {'E', 2},
            {'F', 3}, {'G', 3}, {'H', 3}, {'I', 4}, {'J', 5},
            {'K', 5}, {'L', 5}, {'M', 5}, {'N', 5}, {'O', 6},
            {'P', 7}, {'Q', 7}, {'R', 7}, {'S', 7}, {'T', 7},
            {'U', 8}, {'V', 9}, {'W', 9}, {'X', 9}, {'Y', 9}, {'Z', 9},

            {'a', 9}, {'b', 8}, {'c', 8}, {'d', 8}, {'e', 7},
            {'f', 6}, {'g', 6}, {'h', 6}, {'i', 5}, {'j', 4},
            {'k', 4}, {'l', 4}, {'m', 4}, {'n', 4}, {'o', 3},
            {'p', 2}, {'q', 2}, {'r', 2}, {'s', 2}, {'t', 2},
            {'u', 1}, {'v', 0}, {'w', 0}, {'x', 0}, {'y', 0}, {'z', 0},

            {' ', 0}
        };

        public string Question1(string input)
        {
            string output = "";

            foreach (var ch in input.ToCharArray())
            {
                if (dictionary.TryGetValue(ch, out int value))
                {
                    output += value;
                }
            }
            Console.WriteLine($"Question 1 : input {input} => output {output.ToString()}");
            return output;
        }

        public int Question2(string input)
        {
            var inputArray = input.ToCharArray().Select(x => Convert.ToInt32(x.ToString())).ToArray();

            var expression = new StringBuilder();
            for (int i = 0; i < inputArray.Length; i++)
            {

                var val = $"{inputArray[i]}{(i % 2 == 0 && i < inputArray.Length - 1 ? "+" : i % 2 != 0 && i < inputArray.Length - 1 ? "-" : "")}";
                expression.Append(val);

            }
            // convert string to expression
            var result = new DataTable().Compute(expression.ToString(), null);
            Console.WriteLine($"Question 2 : input {input} => explanation {expression.ToString()} => output => {result}");

            return Convert.ToInt32(result);

        }

        public string Question3(int input)
        {
            input = Math.Abs(input); // Make input absolute value
            int sum = 0;
            int sequence = 0;
            var explanation = new StringBuilder();
            while (sum < input)
            {

                if (sum > input)
                {
                    break;
                }
                if (sum + sequence > input)
                {
                    sequence = 0;
                }
                sum += sequence;
                explanation.Append(sequence + " ");
                sequence += 1;

            }
            var exp = explanation.ToString().Trim().Split(" ").Select(x => Convert.ToInt32(x)).ToList();
            string output = "";
            foreach (var item in exp)
            {

                var reverseDict = dictionary.GroupBy(x => x.Value).ToDictionary(group => group.Key, group => group.Select(kvp => kvp.Key).ToList());
                if (reverseDict.TryGetValue(item, out var keys))
                {
                    output += keys.FirstOrDefault().ToString();
                }

            }

            Console.WriteLine($"Question 3 : input {input} => explanation {string.Join("+", explanation.ToString().Trim().Split())} => output => {output}");
            return output;
        }

        public string Question4(string input)
        {
            var inputArray = input.ToCharArray().Select((value, i) => (value, i)).ToList();
            var outputTotal = 0;
            var inputTotal = 0;
            var output = "";
            var newOutput = "";

            var last2valueIdx = new int[] { inputArray.Count - 1, inputArray.Count - 2 };
            foreach (var (item, index) in inputArray)
            {
                if (dictionary.TryGetValue(item, out int value))
                {
                    inputTotal += value;
                }
            }
            foreach (var (item, index) in inputArray)
            {

                if (!dictionary.TryGetValue(item, out int value)) continue;
                if (last2valueIdx.Contains(index))
                {
                    int newValue = value + 1;
                    var newKey = dictionary.Where(x => x.Value == newValue).FirstOrDefault().Key;
                    output += newKey;
                    newOutput += newValue;

                }
                else
                {
                    output += item;
                    newOutput += value;

                }
                outputTotal += value;


            }

            Console.WriteLine($"Question 4 : input {input} => explanation {string.Join("+", newOutput.ToCharArray())} => output => {output}");
            return output;
        }

        public string Question5(string input)
        {
            var inputArray = input.ToCharArray();
            string values = "";
            string explanation = "";

            foreach (var item in inputArray)
            {
                if (dictionary.TryGetValue(item, out int v))
                {
                    if (v % 2 == 0)
                    {
                        v += 1;
                        explanation += $"({v - 1}+1) ";
                    }
                    else
                    {
                        explanation += $"({v}+0) ";

                    }
                    values += v;

                }
            }
            Console.WriteLine($"Question 5 : input {input} => explanation {string.Join("+", explanation.Trim().Split(" "))} => output => {values}");

            return values;
        }
    }
}