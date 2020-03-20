using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApplication {

  // 链表节点
  public class Node<T> {
    public Node<T> Next { get; set; }
    public T Data { get; set; }

    public Node(T t) {
      Next = null;
      Data = t;
    }
  }

  //泛型链表类
  public class GenericList<T> {
    private Node<T> head;
    private Node<T> tail;

    public GenericList() {
      tail = head = null;
    }

    public Node<T> Head {
      get => head;
    }

    public void Add(T t) {
      Node<T> n = new Node<T>(t);
      if (tail == null) {
        head = tail = n;
      }else {
        tail.Next = n;
        tail = n;
      }
    }
    public void Foreach(Action<T> action){
      for (Node<T> node = this.Head; node != null; node = node.Next)
      {
          action(node.Data);
      }
    }
  }

    class Program
    {
        static void Main(string[] args)
        {
            // 整型List
            GenericList<int> intlist = new GenericList<int>();
            int[] array = { 2, 4, 6, 8, 12, 10, 3, 33, 1, 14 };
            foreach (int i in array)
            {
                intlist.Add(i);
            }
            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;
            // intlist.Foreach(m => Console.WriteLine(m));
            intlist.Foreach(m => { if (m > max) max = m; });
            Console.WriteLine($"最大值为:{max}");
            intlist.Foreach(m => { if (m < min) min = m; });
            Console.WriteLine($"最小值为：{min}");
            intlist.Foreach(m => { sum += m; });
            Console.WriteLine($"总和为：{sum}");

        }
    }
}