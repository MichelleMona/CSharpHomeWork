using System;

namespace 数组
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("数组长度为：");
            int length = int.Parse(Console.ReadLine());
            int[] array = new int[length];
            for(int i=0;i<length;i++)
            {
                Console.WriteLine("数组中第" + (i+1) + "个数");
                array[i] = int.Parse(Console.ReadLine());
            }
            int sum = 0;
            int ave = 0;
            foreach(int num in array)
            {
                sum = sum + num;
            }
            ave = sum / length;
            Array.Sort(array);
            Console.WriteLine("和为" + sum + "均值为" + ave);
            Console.WriteLine("最小数为" + array[0] + "最大数为" + array[length-1]);
        }
    }
}
