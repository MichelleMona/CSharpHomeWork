using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample {

  //声明一个委托类型，定义事件处理函数的格式 
  public delegate void ClickHandler(object sender,
                                    ClickEventArgs args);
  public class ClickEventArgs {
    public int X { get; set; }
    public int Y { get; set; }
  }

  public class Button {
    //定义事件，相当于创建一个委托实例
    public event ClickHandler OnClick;

    public void Click(int x, int y) {
      Console.WriteLine($"Click button on {x},{y}");
      ClickEventArgs args = new ClickEventArgs() {
        X = x,Y = y
      };
      //触发onClick事件
      OnClick(this, args);

    }
  }

  public class Form {
    public Button button1 = new Button();

    public Form() {
      //为btn的OnClick事件添加两个处理方法
      button1.OnClick += new ClickHandler(Btn_OnClick); 
      button1.OnClick += Btn_OnClick2;
    }

    void Btn_OnClick(object sender, ClickEventArgs args) {
      Console.WriteLine($"Button被点击了！");
    }

    void Btn_OnClick2(object sender, ClickEventArgs args) {
      Console.WriteLine("Hello,World!");
    }
  }

  class Program {
    static void Main(string[] args) {
      Form form1 = new Form();
      form1.button1.Click(100, 200);//模拟点击按钮
    }
  }

 




}
