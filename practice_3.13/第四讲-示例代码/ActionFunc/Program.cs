using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFunc {
  class Program {
    static void Method1() {
      Console.WriteLine("Method1");
    }
    static void Method2(string str) {
      Console.WriteLine("Method2:" + str);
    }
    static void Method3(string str1,string str2) {
      Console.WriteLine("Method3:" + str1+","+str2);
    }

    static int Method4(string str) {
      return str.Length;
    }
    static int Method5(string str1, string str2) {
      return str1.Length+ str2.Length;
    }

    static void Main(string[] args) {
      Action action1 = Method1;
      action1();
      Action<string> action2 = Method2;
      action2("jia");
      Action<string,string> action3 = Method3;
      action3("hello","jia");

      Func<string, int> fun1 = Method4;
      Console.WriteLine(fun1("jia"));
      Func<string, string,int> fun2 = Method5;
      Console.WriteLine(fun2("jia","hello"));

      string[] array = { "Hello", "world", "!" };
      Array.ForEach(array, action2);
      Array.ForEach(array, Method2);

    }
  }
}
