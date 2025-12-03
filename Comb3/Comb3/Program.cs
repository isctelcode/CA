using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Comb3
{
    class Program
    {
        static void WordGeneration(int n, string alphabet, string word, int wordLength, int[] repLet, StreamWriter input)
        {
            if (wordLength == n)
            {
                for (int i = 0; i < alphabet.Length; ++i)
                {
                    if (repLet[i] == 0)
                    {
                        return;
                    }
                }
                input.WriteLine(word);
                return;
            }

            for (int i = 0; i < alphabet.Length; ++i)
            {
                int[] newRepLet = new int[alphabet.Length];
                for (int j = 0; j < alphabet.Length; ++j)
                {
                    newRepLet[j] = repLet[j];
                }
                ++newRepLet[i];
                WordGeneration(n, alphabet, word + alphabet[i], wordLength + 1, newRepLet, input);
            }
        }

        static void Main(string[] args)
        {
            using (StreamWriter input = new StreamWriter("data.txt", false, System.Text.Encoding.Default))
            {
                int n = 9;
                string alphabet = "abcdefghjk";
                for (int first = 0; first < n - 2; ++first)
                {
                    for (int second = first + 1; second < n - 1; ++second)
                    {
                        for (int third = second + 1; third < n; ++third)
                        {
                            WordGeneration(9, Convert.ToString(alphabet[first]) + Convert.ToString(alphabet[second]) + Convert.ToString(alphabet[third]), "", 0, new int[] { 0, 0, 0 }, input);
                        }
                    }
                }
                Console.WriteLine("Данные успешно сохранены в файл");
            }
        }
    }
}
