using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMulti {
  
  class Caculator {
    public  void Add(int a, int b) {
      Console.WriteLine($"{a}+{b}={a+b} ");
    }
    public  void Sub(int a, int b) {
      Console.WriteLine($"{a}-{b}={a - b} ");
    }
    public  void Mul(int a, int b) {
      Console.WriteLine($"{a}*{b}={a * b} ");
    }
    public  void Div(int a,int b) {
      Console.WriteLine($"{a}/{b}={a / b} ");
    }
  }
  class Test {
    static void Main() {
      Caculator caculator = new Caculator();
      Action<int, int> p = caculator.Add;
      p += caculator.Sub;
      p += caculator.Mul;
      p += caculator.Div;
      p(5, 8);
    }
  }
}
