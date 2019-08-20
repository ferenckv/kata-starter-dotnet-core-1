using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string  s = "")
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var separators = new[]{",", "\n"};
            var userInput = s;

            if (userInput.StartsWith("//"))
            {
                var parts = userInput.Split('\n');

                separators = new[] {parts.First().Replace("//", "")};
                userInput = parts.Last();
            }

            var numbers = userInput.Split(separators, StringSplitOptions.None).Select(int.Parse).ToArray();

            var negatives = numbers.Where(x => x < 0);
            if (negatives.Any())
            {
                throw  new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }
            return numbers.Sum();
        }
    }
}
