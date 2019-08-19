using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s="")
        {
            if(string.IsNullOrEmpty(s))
                return 0;

            var separator = new []{",", "\n"};
            var userInput = s;

            if (s.StartsWith("//"))
            {
                var parts = s.Split("\n");
                userInput = parts[1];
                separator = new[] {parts[0].Replace("//", "")};

            }
            var numbers = userInput.Split(separator, StringSplitOptions.None).Select(int.Parse).ToArray();

            return numbers.Sum();
        }
    }
}
