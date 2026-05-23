using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int ProductQuanity { get; set; }
        public CartItem(Product product,int productquantity)
        {
            Product = product;
            ProductQuanity = productquantity;
        }
    }
}
