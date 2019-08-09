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

            var array = userInput.Split(",").Select(int.Parse).ToArray();
            if (array.Length == 1)
                return array.First();
            
            return array.First() + array.Last();
        }
    }
}