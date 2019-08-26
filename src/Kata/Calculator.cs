using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "0")
        {
            var numbers = s.Split(new[]{",","\n"}, StringSplitOptions.None).Select(int.Parse);

            return numbers.Sum();
        }
    }
}