using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comb1
{
    class Program
    {
        static void WordGeneration(int n, int k, string alphabet, string word, int wordLength, int[] repLet, StreamWriter input)
        {
            if (wordLength == n)
            {
                int rep2 = 0, repK = 0;
                for (int i = 0; i < 10; ++i)
                {
                    if (repLet[i] == 2)
                    {
                        ++rep2;
                    }
                    else if (repLet[i] == k)
                    {
                        ++repK;
                    }
                    else if (repLet[i] > 1)
                    {
                        return;
                    }
                }
                if (rep2 == 3 && repK == 1)
                {
                    input.WriteLine(word);
                }
                return;
            }

            for (int i = 0; i < alphabet.Length; ++i)
            {
                if (repLet[i] == k)
                {
                    continue;
                }
                int[] newRepLet = new int[alphabet.Length];
                for (int j = 0; j < alphabet.Length; ++j)
                {
                    newRepLet[j] = repLet[j];
                }
                ++newRepLet[i];
                WordGeneration(n, k, alphabet, word + alphabet[i], wordLength + 1, newRepLet, input);
            }
        }

        static void Main(string[] args)
        {
            using (StreamWriter input = new StreamWriter("data.txt", false, System.Text.Encoding.Default))
            {
                bool flag = true;
                int n = 0, k = 0;
                while (flag)
                {
                    Console.Write("Введите значение n и k (k не равно 2) >> ");
                    int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    n = nk[0]; k = nk[1];
                    if (k < 3 || n < k + 6 || n > k + 12)
                    {
                        Console.WriteLine("Некорректные данные");
                    }
                    else
                    {
                        flag = false;
                    }
                }
                string alphabet = "abcdefghjk";
                WordGeneration(n, k, alphabet, "", 0, new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, input);
                Console.WriteLine("Данные успешно сохранены в файл");
            }
        }
    }
}
