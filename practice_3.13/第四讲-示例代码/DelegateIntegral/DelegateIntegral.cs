using System;



public class DelegateIntegral {

  delegate double Func(double x); //定义一个委托类型Func
  
  // 积分计算,使用委托作为参数
  static double Integral(Func f, double a, double b) {
    double eps = 1e-3;
    int n = 1;
    double s, x, t = 0;
    double h = b - a;
    double t1 =h * (f(a) + f(b)) / 2.0;//调用委托
    double p= double.MaxValue;

    // 迭代计算
    while (p >= eps) {
      s = 0.0;
      for (int k = 0; k <= n - 1; k++) {
        x = a + (k + 0.5) * h;
        s = s + f(x);
      }

      t = (t1 + h * s) / 2.0;
      p = Math.Abs(t1 - t);
      t1 = t;
      n = n + n;
      h = h / 2.0;
    }
    return t;
  }
  public static void Main() {
    //使用委托实例作为参数
    Func f = Math.Sin;
    double d = Integral(f, 0, Math.PI / 2);
    Console.WriteLine(d);

    double d2 = Integral(Linear, 0, 2); 
    Console.WriteLine(d2);

    //使用lambda表达式作为参数
    double d3 = Integral(x=> x*2+1, 0, 2);
    Console.WriteLine(d3);
  }

  static double Linear(double a) {
    return a * 2 + 1;
  }

 
}
