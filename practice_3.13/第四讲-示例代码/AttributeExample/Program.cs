using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeExample {
  class Program {
    static void Main(string[] args) {
      PrintAttribute(typeof(MyClass));
    }

    public static void PrintAttribute(Type t) {
      MyAttribute classAttr = 
        (MyAttribute)t.GetCustomAttribute(typeof(MyAttribute));
      if (classAttr!= null){
        Console.WriteLine($"{t.Name}:{classAttr.Name}");
      }
      MethodInfo[] methods = t.GetMethods();
      for(int i = 0; i < methods.Length; i++) {
        MyAttribute methodAttr =
          (MyAttribute)methods[i].GetCustomAttribute(typeof(MyAttribute));
        if (methodAttr == null) continue;
        Console.WriteLine($"{methods[i].Name}:{methodAttr.Name}");
      }
    }
  }

  [MyAttribute("Hello, attribute")]
  public class MyClass {

    [MyAttribute("hello")]
    public void Method1() {
      //...
    }

    [MyAttribute("world")]
    public void Method2() {
      //...
    }

  }

  public class MyAttribute : Attribute {
    private string name;

    public string Name { get=> name; }

    public MyAttribute(string name) {
      this.name = name;
    }
  }
}