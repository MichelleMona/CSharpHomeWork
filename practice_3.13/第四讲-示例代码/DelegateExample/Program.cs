using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample {

  delegate int Fun(int num); //定义一个委托类型

  class Program {
    //delegate int Fun(int num); //定义一个委托类型

    static void Main(string[] args) {
      //创建静态方法委托实例
      Fun fun1 = new Fun(Program.AddOne); 
      Fun fun2 = AddOne;

      //创建非静态方法委托实例
      Program p = new Program();
      Fun fun3 = new Fun(p.AddTwo);  
      Fun fun4 = p.AddTwo;

      //调用委托实例
      Console.WriteLine(fun1(1)); 
      Console.WriteLine(fun2(1));
      Console.WriteLine(fun1(3)); 
      Console.WriteLine(fun2(4));
    }

    static int AddOne(int num) {
      return num + 1;
    }

    int AddTwo(int num) {
      return num + 2;
    }


  }
}
