using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
                return 0;

            var numbers = userInput.Split(',').Select(int.Parse).ToArray();

            if (numbers.Count() == 1)
                return numbers[0];

            return numbers[0] + numbers[1];
        }
    }
}