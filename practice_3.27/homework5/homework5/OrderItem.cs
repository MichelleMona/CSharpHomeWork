using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
   public  class OrderItem
    {
        public string tradeName { get; set; }//商品名
        public double unitPrice { get; set; }//单价
        public int number { get; set; }//数量
        public double total { get; set; }//总金额
        public override bool Equals(object obj)
        {
            OrderItem orderItem = obj as OrderItem;
            return orderItem != null && orderItem.tradeName == this.tradeName && orderItem.number == this.number;
        }
        public override string ToString()
        {
            return $"订单明细：商品名：{tradeName} 单价：{unitPrice} 数量：{number} 总金额：{total}";
        }
        public OrderItem(string tradeName,  int number)
        {
            this.tradeName = tradeName;
            this.unitPrice = 10;
            this.number = number;
            this.total = unitPrice * number;

        }

    }
}
