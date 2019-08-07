using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput="")
        {
            if(string.IsNullOrEmpty(userInput))
                return 0;

            var separators = new char[] {',', '\n'};
            var numbers = userInput.Split(separators).Select(int.Parse).ToArray();
            return numbers.Sum();
        }
    }
}