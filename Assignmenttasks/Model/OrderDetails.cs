using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.Model
{
    public class OrderDetail
    {

        public int OrderDetailID { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public OrderDetail() { }

        public OrderDetail(int orderDetailId, Order order, Product product, int quantity)
        {
            OrderDetailID = orderDetailId;
            Order = order;
            Product = product;
            Quantity = quantity;
        }


        public decimal CalculateSubtotal()
        {
            return Product.Price * Quantity;
        }
        public void GetOrderDetailInfo()
        {
            Console.WriteLine($"Order Detail ID: {OrderDetailID}");
            Console.WriteLine($"Order ID: {Order.OrderID}");
            Console.WriteLine($"Product: {Product.ProductName}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Subtotal: ${CalculateSubtotal()}");
        }
        public override string ToString()
        {
            return $"Order detail ID is {OrderDetailID}, Quantity is {Quantity}"; 
        }

    }
}
