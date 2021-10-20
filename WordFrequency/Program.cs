using System;
using System.Collections.Generic;

namespace WordFrequency
{
    class Program
    {
        static string[] SYMBOLS = {" ", ",", "."};
        static Dictionary<string, int> GetCountOfWord(string text) {
            Dictionary<string, int> output = new Dictionary<string, int>();

            string[] words = text.ToLower().Split(SYMBOLS, StringSplitOptions.RemoveEmptyEntries);

            foreach(string word in words) {
                if(output.ContainsKey(word)) {
                    output[word] += 1;
                }
                else {
                    output[word] = 1;
                }
            }

            return output;
        }
        static void Main(string[] args)
        {
            string text = "one two three one Two two four three . five six four one";
            Dictionary<string, int> dict = GetCountOfWord(text);
            foreach(KeyValuePair<string, int> keyValue in dict) {
                Console.WriteLine(keyValue.Key + " " + keyValue.Value);
            }
        }
    }
}
