using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput="")
        {
            if (string.IsNullOrEmpty(userInput))
                return 0;
            var separator = new []{",", "\n"};
            var input = userInput;

            if (input.StartsWith("//"))
            {
                var parts = input.Split("\n");
                input = parts[1];
                separator = new[] { parts[0].Replace("//","") };
            }
            var numbers = input.Split(separator, StringSplitOptions.None).Select(int.Parse).ToArray();

            return numbers.Sum();
        }
    }
}
