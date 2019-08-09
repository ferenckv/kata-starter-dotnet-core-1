using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput="")
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return 0;
            }

            var delimiters = new []{",", "\n"};
            var input = userInput;
            

            if (userInput.StartsWith("//"))
            {
                var inputParts = userInput.Split('\n');

                var customeDelimiters = inputParts.First()
                    .Replace("//", "")
                    .Replace("[", "")
                    .Replace("]", "");
                delimiters = new[] {customeDelimiters};

                input = inputParts.Last();
            }
            
            var array = input.Split(delimiters, StringSplitOptions.None).Select(int.Parse)
                .Where(x=> x<1001)
                .ToArray();

            var negatives = array.Where(x => x < 0).ToArray();
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }

            return array.Sum();
        }
    }
}