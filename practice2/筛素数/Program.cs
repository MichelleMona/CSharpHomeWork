using System;

namespace 筛素数
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] isprime = new bool[101];            
            for (int i = 0; i < isprime.Length; i++)
                isprime[i] = true;
            isprime[0] = isprime[1] = false;            
            Console.WriteLine("2-100内的素数为：");
            for (int i = 2; i <= 10; i++)       
            {
                if (!isprime[i])       
                {
                    continue;
                }
                for (int j = i * 2; j <= 100; j = j + i)  
                    isprime[j] = false;
            }
            for (int k = 0; k < isprime.Length; k++)
            {
                if (isprime[k])
                    Console.Write(k + "   ");
            }
        }
    }
}
