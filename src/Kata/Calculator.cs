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
                delimiters = new[] {userInput[2].ToString()};
                userInput = userInput.Substring(4);
            }
            
            var nums = userInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToArray();

            var negs = nums.Where(x => x < 0);
            if (negs.Any()) throw new Exception($"negatives not allowed: {string.Join(", ",negs)}");

            var validNums = nums.Where(x => x < 1001);
            return validNums.Sum();
        }
    }
}