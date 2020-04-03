using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
   public  class orderSystemManager
    {
        public OrderService  orderService= new OrderService();

        public void init()
        {
            Console.WriteLine("欢迎使用订单控制系统");
        }
        public Order createOrder()//用户输入订单
        {
            string itemName;
            int num;
            string consumer;
            Console.WriteLine("请输入你想购买的东西：");
            itemName=Console.ReadLine();
            Console.WriteLine("请输入你的名字");
            consumer = Console.ReadLine();
            Console.WriteLine("请输入你想购买东西的数量：");
            num= Console.Read();

            OrderItem orderItem = new OrderItem(itemName, num);

            Order order = new Order(consumer, orderItem);
            return order;
           
        }
        public void createRandomOrders(int n)//随机创建订单
        {
            Random random = new Random();
            int[] nums = new int[n];
            string[] itemNames = new string[n];
            string[] consumers = new string[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = random.Next(100);
                itemNames[i] = "name" + random.Next(100).ToString();
                consumers[i] = "consumers" + random.Next(100).ToString();
                OrderItem orderItem = new OrderItem(itemNames[i], nums[i]);
                Order order = new Order(consumers[i], orderItem);
                this.orderService.addOrder(order);
            }
        }
        public void inquiryOrder()
        {
            string selection;
            int a;

            Console.WriteLine("下面请进行查询：");
            Console.WriteLine("请按照消费者或商品名查询");
            Console.WriteLine("请输入您要查询的消费者或商品");

            selection = Console.ReadLine();

            Console.WriteLine("您搜索的关键词是" + selection);
            this.orderService.selectOrder(selection);
          
            Console.WriteLine("请用订单号查询");
            Console.WriteLine("请输入您要查询的订单号：");
             a = Console.Read();
            Console.WriteLine("您搜索的关键词是" + a.ToString());
            this.orderService.selectOrder(a);
        }

    }
}
