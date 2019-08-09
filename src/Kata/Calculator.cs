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

                delimiters = new[] {inputParts.First().Replace("//", "")};

                input = inputParts.Last();
            }
            
            var array = input.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToArray();
            

            return array.Sum();
        }
    }
}