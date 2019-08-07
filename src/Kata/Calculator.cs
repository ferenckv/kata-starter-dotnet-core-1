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

            var separators = new char[] {',', '\n'};
            var input = userInput;
            if (userInput.StartsWith("//"))
            {
                var parts = userInput.Split('\n');
                input = parts[1];
                separators = parts[0].Replace("//","").ToCharArray();
            }

            var numbers = input.Split(separators).Select(int.Parse).ToArray();
            var negatives = numbers.Where(n => n < 0).ToArray();

            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {negatives.First()}");
            }
            return numbers.Sum();
        }
    }
}