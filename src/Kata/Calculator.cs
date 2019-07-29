using System;
using System.Globalization;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return 0;
            }

            var delimiters = new []{",", "\n"};

            if (userInput.StartsWith("//"))
            {
                var stringParts = userInput.Split('\n');
                delimiters = new[] {stringParts[0].Replace("//", "").Replace("[", "").Replace("]","")};
                userInput = stringParts[1];
            }
            
            var nums = userInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToArray();

            var negs = nums.Where(x => x < 0);
            if (negs.Any()) throw new Exception($"negatives not allowed: {string.Join(", ",negs)}");

            var validNums = nums.Where(x => x < 1001);
            return validNums.Sum();
        }
    }
}