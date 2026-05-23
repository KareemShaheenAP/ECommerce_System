using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce_System.Products;
namespace ECommerce_System.Carts
{
    public class Cart
    {
        public List<CartItem> Items = new List<CartItem>();

        public bool AddToCart(Product product, int productquantity)
        {
            if (product.StockQuantity < productquantity)
            {
                return false;
            }
            Items.Add(new CartItem(product, productquantity));
            product.StockQuantity -= productquantity;
            return true;
        }

        public bool RemoveFromCart(int productid)
        {
            foreach (var item in Items)
            {
                if (item.Product.Id == productid)
                {
                    item.Product.StockQuantity += item.ProductQuanity;
                    Items.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public void ViewItems()
        {
            if (Items.Count == 0) 
            {
                Console.WriteLine("No Items Available");
            }
            else
            {
                Console.WriteLine("\n--- Cart Items ---");
                foreach (var item in Items)
                {
                    Console.WriteLine($"ID: {item.Product.Id} - Name: {item.Product.Name} - Qty: {item.ProductQuanity}");
                }
            }  
        }

        public double CalculateTotalPrice()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("No Items Available");
                return 0;
            }
            else 
            {
                double totalPrice = 0;

                foreach (var item in Items)
                {
                    totalPrice += item.Product.Price * item.ProductQuanity;
                }
                return totalPrice;
            }
        }
    }
}
