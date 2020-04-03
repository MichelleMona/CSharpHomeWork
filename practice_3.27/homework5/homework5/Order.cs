using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    public class Order
    {
        public long orderNum { get; set; }//订单号
        public string orderTime { get; set; }//订单时间
        public string consumer { get; set; }//消费者
        public double totalSum { get; set; }//总价
        public int orderItemNum = 1;//明细数量
        public OrderItem[] orderItems = new OrderItem[100];
        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order != null && order.orderNum == this.orderNum && order.orderTime == this.orderTime;
        }
        public override string ToString()
        {
            string firstStr = $"订单号：{orderNum} 下单时间：{orderTime} 消费者：{consumer} 总金额：{totalSum}";
            string str = null;
            for (int i = 0; i < this.orderItemNum; i++)
            {
                string secondStr = orderItems[i].ToString();
                str += secondStr;
            }
            return firstStr+"\r\n"+str;
        }
        public void addOrderItem(OrderItem orderItem)
        {
            orderItems[orderItemNum] = orderItem;
            orderItemNum += 1;
            this.totalSum += orderItem.total;
        }
        public Order( string consumer, OrderItem orderItem)
        {
            System.Threading.Thread.Sleep(1000);
            this.orderTime = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            this.orderNum = long.Parse("1" + this.orderTime);
            this.consumer = consumer;
            this.totalSum = orderItem.total;
            this.orderItems[orderItemNum - 1] = orderItem;
        }
        
    }
}
