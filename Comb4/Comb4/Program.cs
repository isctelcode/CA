using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comb4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter input = new StreamWriter("data.txt", false, System.Text.Encoding.Default))
            {
                for (int x1 = 1; x1 <= 8; ++x1)
                {
                    for (int x2 = 9; x2 <= 100; ++x2)
                    {
                        for (int x3 = 1; x3 <= 7; ++x3)
                        {
                            for (int x4 = 11; x4 <= 100; ++x4)
                            {
                                for (int x5 = 1; x5 <= 6; ++x5)
                                {
                                    for (int x6 = 12; x6 <= 100; ++x6)
                                    {
                                        for (int x7 = 1; x7 <= 5; ++x7)
                                        {
                                            for (int x8 = 12; x8 <= 100; ++x8)
                                            {
                                                if (x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 == 100)
                                                {
                                                    input.WriteLine($"{x1} {x2} {x3} {x4} {x5} {x6} {x7} {x8}");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Данные успешно сохранены в файл");
            }
        }
    }
}
