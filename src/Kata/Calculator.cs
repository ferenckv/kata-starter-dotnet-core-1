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

            var nums = userInput.Split(",").Select(int.Parse).ToList();
            if (nums.Count == 1)
                return nums.First();
            
            return nums.First() + nums.Last();
        }
    }
}