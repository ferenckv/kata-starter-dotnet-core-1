using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s="")
        {
            if(string.IsNullOrEmpty(s))
                return 0;

            var separator = new []{",", "\n"};
            var userInput = s;

            if (s.StartsWith("//"))
            {
                var parts = s.Split("\n");
                userInput = parts[1];
                separator = new[] {parts[0].Replace("//", "")};

            }
            var numbers = userInput.Split(separator, StringSplitOptions.None).Select(int.Parse).ToArray();

            var negatives = numbers.Where(n => n < 0).ToArray();

            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {negatives.First()}");
            }

            return numbers.Sum();
        }
    }
}
