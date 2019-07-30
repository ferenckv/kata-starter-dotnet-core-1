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
                
                var custom = parts[0]
                    .Replace("//","")
                    .Replace("[","")
                    .Replace("]","");
                
                separator = new[] {custom};
            }

            var numbers = input.Split(separator, StringSplitOptions.None).Select(int.Parse).Where((x) => x < 1001)
                .ToArray();

            var negatives = numbers.Where((x) => x < 0).ToArray();
            
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }


            return numbers.Sum();
        }
    }
}