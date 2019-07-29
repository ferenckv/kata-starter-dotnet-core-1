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

            var nums = userInput.Split(",").Select(int.Parse).ToArray();
            return nums.Sum();
        }
    }
}