using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comb5
{
    class Program
    {
        static void WordGeneration(int n, string alphabet, string word, int wordLength, int[] repLet, StreamWriter input)
        {
            if (wordLength == n)
            {
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
                if (newRepLet[i] == 0)
                {
                    continue;
                }
                --newRepLet[i];
                WordGeneration(n, alphabet, word + alphabet[i], wordLength + 1, newRepLet, input);
            }
        }

        static void Main(string[] args)
        {
            using (StreamWriter input = new StreamWriter("data.txt", false, System.Text.Encoding.Default))
            {
                string alphabet = "КОНТЕЙР";
                WordGeneration(9, alphabet, "", 0, new int[] { 1, 1, 2, 1, 2, 1, 1 }, input);
                Console.WriteLine("Данные успешно сохранены в файл");
            }
        }
    }
}
