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
    Console.WriteLine($"�Ǽǣ�{name}��{num}");
    if (num < 0) {
      throw new RegisterException("����Ϊ��ֵ��������", 3);
    }
  }

  public static void Manage(string name,int id) {
    try {
      Register(name,id);
      Console.WriteLine("�Ǽǳɹ�");
    }
    catch (RegisterException e) {
      Console.WriteLine("�Ǽ�ʧ�ܣ��������" + e.Code);
    }
    Console.WriteLine("���εǼǽ���");
  }
  public static void Main() {
    Test.Manage("li", 100);
    Test.Manage("jia",-100);
  }
}
