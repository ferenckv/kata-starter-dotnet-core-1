using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "0")
        {
            var delimiters = new[]{",","\n"};
            var userInput = s;

            if (userInput.StartsWith("//"))
            {
                var parts = userInput.Split('\n');
                delimiters = new[] {parts
                    .First()
                    .Replace("//", "")
                    .Replace("[", "")
                    .Replace("]", "")
                };
                userInput = parts.Last();
            }
            
            var numbers = userInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse)
                .Where(x=> x<=1000);
            var negatives = numbers.Where(x => x < 0);
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }

            return numbers.Sum();
        }
    }
}