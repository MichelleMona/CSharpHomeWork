using System;

namespace 质数因子
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入一个数字:");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("素数因子为:");
            for (int i=2;i<=input;i++)
            {
                if (input % i == 0 )
                {
                    Console.WriteLine(i);
                    do
                    {
                        input /= i;
                    } while (input % i == 0);
                }

            }
        }
    }
}
