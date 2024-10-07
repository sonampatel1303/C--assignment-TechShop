using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.Model
{
    public class Product
    {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public Product() { }
        public Product(int productId, string productName, string description, decimal price, int stockQuantity)
        {
            ProductID = productId;
            ProductName = productName;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public override string ToString()
        {
            return $"ProductName is {ProductName}"+
                $"Product Description:{Description}"+
                $"Product Price:{Price}"
                + $"Product Quantity:{StockQuantity}";
        }
    }
}