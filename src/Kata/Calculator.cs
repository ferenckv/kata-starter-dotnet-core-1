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
            return nums.Sum();
        }
    }
}