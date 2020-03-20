using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExample {
  class Program {

    delegate void Func(string str);
    delegate void Func2(string str, string str2);

    static void Main(string[] args) {
      Func print = (string s) => { Console.WriteLine(s); };
      Func print2 = (s) => { Console.WriteLine(s); };
      Func print3 = (s) => Console.WriteLine(s);
      Func print4 = s => Console.WriteLine(s);
      print("Hello");
      print2("Hello");
      print3("Hello");
      print4("Hello");

      Func2 print5 = (s, n) => {
        Console.Write(s + ",");
        Console.Write(n);
      };
      print5("Hello", "jia");


      int[] array = { 1, 2, 3, 4 };
      //匿名方法
      Action<int> action = delegate (int item) {
        Console.WriteLine(item);
      };
      Array.ForEach(array, action);
      //lambda表达式赋值给委托
      Action<int> action2 = (m => Console.WriteLine(m));
      Array.ForEach(array, action2);
      //直接使用Lambda表达式作为参数
      Array.ForEach(array, m => Console.WriteLine(m));

      //求和（lambda表达式中访问局部变量）
      int sum=0;
      Array.ForEach(array, m => sum += m);
      Console.WriteLine($"sum={sum}");
    }

  

  }
}
