using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System
{
    public class OrderService
    {
        public void ProcessOrder(Order order, IPayment payment)
        {
            payment.Pay(order.TotalPrice);

            Console.WriteLine("Order processed successfully.");
        }
    }
}
