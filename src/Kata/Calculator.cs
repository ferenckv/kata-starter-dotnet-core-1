using System;
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

            var delimiters = new[]{",", "\n"};
            var nums = userInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToList();
            return nums.Sum();
        }
    }
}