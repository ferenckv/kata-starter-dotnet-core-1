using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string  userInput = "0")
        {
            var stringOfNumbers = GetStringOfNumbers(userInput);
            var delimiters = GetDelimiters(userInput);

            var numbers = GetValidNumbers(stringOfNumbers, delimiters);

            ValidateNegatives(numbers);
            return numbers.Sum();
        }

        static string GetStringOfNumbers(string userInput)
        {
            if (HasCustomDelimiters(userInput))
            {
                return SplitCustomDelimiterParts(userInput).Last();
            }

            return userInput;
        }

        static string[] GetDelimiters(string originalUserInput)
        {
            var separators = new[] {",", "\n"};

            if (HasCustomDelimiters(originalUserInput))
            {
                separators = SplitCustomDelimiterParts(originalUserInput)
                    .First()
                    .Replace("//", "")
                    .Replace("[", "")
                    .Split(']');
            }

            return separators;
        }

        static string[] SplitCustomDelimiterParts(string originalUserInput)
        {
            return originalUserInput.Split('\n');
        }

        static bool HasCustomDelimiters(string userInput)
        {
            return userInput.StartsWith("//");
        }

        static int[] GetValidNumbers(string userInput, string[] separators)
        {
            var numbers = userInput.Split(separators, StringSplitOptions.None).Select(int.Parse)
                .Where(x => x <= 1000)
                .ToArray();
            return numbers;
        }

        static void ValidateNegatives(int[] numbers)
        {
            var negatives = numbers.Where(x => x < 0).ToArray();
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }
        }
    }
}
