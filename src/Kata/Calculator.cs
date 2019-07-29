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
            if (nums.Count() == 1) return nums[0];
            
            return nums[0] + nums[1];
        }
    }
}