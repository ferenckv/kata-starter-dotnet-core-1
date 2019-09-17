using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var numbers = s.Split(new []{ ',', '\n' }).Select(int.Parse).ToArray();

            return numbers.Sum();
        }
    }
}