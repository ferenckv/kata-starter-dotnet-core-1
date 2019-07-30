using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
                return 0;


            var separator = new string[]{",", "\n"};
            var input = userInput;

            if (userInput.StartsWith("//"))
            {
                var parts = userInput.Split("\n");
                input = parts[1];
                separator = new[] {parts[0].Last().ToString()};
            }
            
            var numbers = input.Split(separator, StringSplitOptions.None).Select(int.Parse).ToArray();

            return numbers.Sum();
        }
    }
}