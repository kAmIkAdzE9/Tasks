using System.Collections.Generic;

namespace endpoints
{
    public class Frequency
    {
        static string[] SYMBOLS = { " ", ",", "." };
        public static Dictionary<string, int> GetCountOfWord(string text)
        {
            Dictionary<string, int> output = new Dictionary<string, int>();

            string[] words = text.ToLower().Split(SYMBOLS, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (output.ContainsKey(word))
                {
                    output[word] += 1;
                }
                else
                {
                    output[word] = 1;
                }
            }

            return output;
        }
    }
}