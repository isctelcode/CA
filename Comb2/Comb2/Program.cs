using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Comb2
{
    class Program
    {
        static void WordGeneration(int n, int k, int m, string alphabet, string word, int wordLength, int[] repLet, StreamWriter input)
        {
            if (wordLength == n)
            {
                if (repLet[0] > 1 && repLet[1] == k && repLet[2] == k && repLet[3] > m)
                {
                    input.WriteLine(word);
                }
                return;
            }

            for (int i = 0; i < alphabet.Length; ++i)
            {
                int[] newRepLet = new int[alphabet.Length];
                for (int j = 0; j < alphabet.Length; ++j)
                {
                    newRepLet[j] = repLet[j];
                }
                if ((i == 0 && repLet[i] == k - 1) || (i == 1 && repLet[i] == k) || (i == 2 && repLet[i] == k) || (i > 3 && repLet[i] == 1))
                {
                    continue;
                }
                ++newRepLet[i];
                WordGeneration(n, k, m, alphabet, word + alphabet[i], wordLength + 1, newRepLet, input);
            }
        }

        static void Main(string[] args)
        {
            using (StreamWriter input = new StreamWriter("data.txt", false, System.Text.Encoding.Default))
            {
                bool flag = true;
                int n = 0, k = 0, m = 0;
                while (flag)
                {
                    Console.Write("Введите значение n и k (k не равно 2) >> ");
                    int[] nkm = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    n = nkm[0]; k = nkm[1]; m = nkm[2];
                    if (k < 3 || m < k || n < 2 * k + m + 3)
                    {
                        Console.WriteLine("Некорректные данные");
                    }
                    else
                    {
                        flag = false;
                    }
                }
                string alphabet = "abcdefghjk";
                WordGeneration(n, k, m, alphabet, "", 0, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, input);
                Console.WriteLine("Данные успешно сохранены в файл");
            }
        }
    }
}
