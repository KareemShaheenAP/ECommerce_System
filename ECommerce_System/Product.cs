using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System
{

    public class Product
    {
        private double _price;
        private int _stockquantity;
        private string _name;
        public int Id { get; }
        public string Name {
            get
            { 
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name is empty");
                }
                else
                {
                    _name = value;
                }
            }
        }
        public double Price {
            get
            {
                return _price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be higher than 0");
                }
                else
                {
                    _price = value;
                }
            }
        }
        public int StockQuantity {
            get
            {
                return _stockquantity;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Quantity must be higher than 0");
                }
                else
                {
                    _stockquantity = value;
                }
            }
        }

        public Product(int id, string name, double price, int stockQuantity)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name is empty");
            }
            if (price <= 0)
            {
                throw new ArgumentException("Price must be higher than 0");
            }
            if (stockQuantity <= 0)
            {
                throw new ArgumentException("Quantity must be higher than 0");
            }
            Id = id;
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }
    }
}
