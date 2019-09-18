using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var separator = new []{",", "\n"};
            var userInput = s;

            if (userInput.StartsWith("//"))
            {
                var parts = userInput.Split("\n");

                separator = new[] {parts.First().Replace("//", "")};
                userInput = parts.Last();
            }
            
            var numbers = userInput.Split(separator, StringSplitOptions.None).Select(int.Parse).ToArray();
            return numbers.Sum();

        }
    }
}