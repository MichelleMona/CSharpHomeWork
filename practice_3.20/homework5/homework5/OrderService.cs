using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 public class MyException : ApplicationException
{
    string error = "";
    private Exception innerException;
    public MyException() { }
    public MyException(string msg):base( msg)
    {
        this.error = msg;
    }
   public MyException(string msg, Exception exception) : base(msg, exception)
    {
        this.innerException = exception;
        this.error = msg;
    }

}

namespace homework5
{
    public class OrderService
    {
        public int orderNum = 0;
        public  List<Order> orders = new List<Order>();
        public void addOrder(Order order)
        {
            orders.Add(order);
            orderNum += 1;
        }
        public void deleteOrder(Order order)
        {
            try
            {
                if (!this.orders.Contains(order))
                {
                    throw new MyException("订单列表中不包含此订单");

                }
                orders.Remove(order);
                orderNum -= 1;
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void modifyOrder(Order oldOrder, Order newOrder)
        {

            try
            {
                if (!this.orders.Contains(oldOrder))
                {
                    throw new MyException("订单列表中不包含此旧订单");

                }
                int index = orders.IndexOf(oldOrder);
                orders.Remove(oldOrder);
                orders.Insert(index, newOrder);
            }
             catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void listSorted()
        {
            this.orders.Sort((Order o1, Order o2) => { return (int)(o1.orderNum / 10000000000) -(int)(o2.orderNum / 10000000000); });
        }
        public void display()
        {
            for (int i = 0; i < this.orderNum; i++)
            {
                Console.WriteLine( orders[i].ToString());
                Console.WriteLine("\r\n");
            }

        }
        public void selectOrder(string str)//通过字符串查询
        {
            bool finded = false;
            for (int i = 0; i < orderNum; i++)
            {
                if (orders[i].consumer.Contains(str))
                {
                    Console.WriteLine("您查询的订单信息如下：");
                    Console.WriteLine( orders[i].ToString());
                    finded = true;
                }
                else 
                {
                    for (int j = 0; j < orders[i].orderItemNum; j++)
                    {
                        if (orders[i].orderItems[j].tradeName.Contains(str))
                        {
                            Console.WriteLine("您查询的订单信息如下：");
                            Console.WriteLine(orders[i].ToString());
                            finded = true;
                        }

                    }

                }

            }
            if (!finded)
            {
                Console.WriteLine("找不到您要找的订单");
            }
            
        }
        public void selectOrder(int num)
        {
            bool finded = false;
            for (int i = 0; i < this.orderNum; i++)
            {
                if (orders[i].orderNum == num)
                {
                    Console.WriteLine("您查询的订单信息如下：");
                    Console.WriteLine(orders[i].ToString());
                    finded = true;
                }

            }
            if (!finded)
            {
                Console.WriteLine("找不到您要找的订单");
            }
        }
    }
}
