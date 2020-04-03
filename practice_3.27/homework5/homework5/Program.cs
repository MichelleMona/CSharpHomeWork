/*写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
  提示：主要的类有Order（订单）、OrderItem（订单明细项），OrderService（订单服务），订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。
  要求：
  （1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
  （2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
  （3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
  （4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
  （5）OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
 * 
 * 
 * 自己输入一个订单，然后程序随机生成一些订单
 * 再对全部订单进行其他操作
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = DateTime.Now.ToString();
            Console.WriteLine(str);
            orderSystemManager orderSystemManager = new orderSystemManager();
            orderSystemManager.init();
            Order order =orderSystemManager.createOrder();
            Console.WriteLine("随机生成订单,请等待");
            orderSystemManager.orderService.addOrder(order);

            orderSystemManager.createRandomOrders(10);
            Console.WriteLine("输出现在所有的订单：");
            orderSystemManager.orderService.display();
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            orderSystemManager.inquiryOrder();
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("查询总金额大于500的订单，并按照总金额顺序输出");
            
            List<Order> orderFindAll = orderSystemManager.orderService.orders.FindAll((Order order1) => { if (order1.totalSum > 500) { return true; } else { return false; } });
            orderFindAll.Sort((Order o1, Order o2) => (int)o1.totalSum - (int)o2.totalSum);
            for (int i = 0; i < orderFindAll.Count; i++)
            {
                Console.WriteLine(orderFindAll[i].ToString());
                Console.WriteLine("\r\n");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
           
        }
    }
}
