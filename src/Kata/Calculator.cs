using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var separator = new []{ ',', '\n' };

            if (s.StartsWith("//"))
            {
                var parts = s.Split("\n");
                separator = new[] {parts[0].Replace("//", "")[0]};
                s = parts[1];
            }
            var numbers = s.Split(separator).Select(int.Parse).ToArray();

            var negatives = numbers.Where(n => n < 0).ToArray();

            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {negatives.First()}");
            }

            return numbers.Sum();
        }
    }
}