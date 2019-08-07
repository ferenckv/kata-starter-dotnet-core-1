using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput="")
        {
            if(string.IsNullOrEmpty(userInput))
                return 0;

            var separators = new [] {",", "\n"};
            var input = userInput;
            if (userInput.StartsWith("//"))
            {
                var parts = userInput.Split('\n');
                input = parts[1];
                separators = new []{parts[0].Replace("//", "")
                        .Replace("[", "")
                        .Replace("]", "")
                    };
            }

            var numbers = input.Split(separators, StringSplitOptions.None).Select(int.Parse).Where(n => n < 1001).ToArray();
            var negatives = numbers.Where(n => n < 0).ToArray();

            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }
            return numbers.Sum();
        }
    }
}