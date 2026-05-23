using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System
{
    public class Order
    {
        public List<CartItem> Items { get; set; }
        public double TotalPrice { get; set; }
        public Order(List<CartItem> items, double total)
        {
            Items = items;
            TotalPrice = total;
        }
    }
}
