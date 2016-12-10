using System.Linq;

namespace Titanium2016.Test
{
    public static class Helpers
    {
        public static string Reflect(string input)
        {
            return new string(input.Reverse().Select(i => i == '(' ? ')' : '(').ToArray());
        }
    }
}