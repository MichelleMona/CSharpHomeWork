using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerecType {
  class Program {
    static void Main(string[] args) {
      Test1();

    }

    private static void Test1() {
      ArrayList arrayList = new ArrayList();
      arrayList.Add('a');
      arrayList.Add("a");

      foreach (Object item in arrayList) {
        char c = (char)item; //产生InvalidCastException
        Console.WriteLine($"{c}={(int)c}" );
      }
    }

    private static void Test2() {
      List<char> list = new List<char> ();
      list.Add('a');
      list.Add("a");

      foreach (char c in list) {
        Console.WriteLine($"{c}={(int)c}");
      }

      //list.ForEach(new Action<string>(PrintItem));

      //list.ForEach(item => Console.WriteLine("item"));

    }

    private static void PrintItem(string item) {
      Console.WriteLine("item = " + item);
    }
  }
}
