using System;
class RegisterException : ApplicationException {
  private int code;
  public RegisterException(String message, int code)
   : base(message) {
    this.code = code;
  }
  public int Code { get => code; }
}

public class Test {

  public static void Register(string name,int num) {
    Console.WriteLine($"登记：{name}，{num}");
    if (num < 0) {
      throw new RegisterException("号码为负值，不合理", 3);
    }
  }

  public static void Manage(string name,int id) {
    try {
      Register(name,id);
      Console.WriteLine("登记成功");
    }
    catch (RegisterException e) {
      Console.WriteLine("登记失败，错误代码" + e.Code);
    }
    Console.WriteLine("本次登记结束");
  }
  public static void Main() {
    Test.Manage("li", 100);
    Test.Manage("jia",-100);
  }
}
