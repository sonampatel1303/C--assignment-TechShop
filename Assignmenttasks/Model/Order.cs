using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.Model
{
    public class Order
    {

        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get;  set; }

        public string Status {  get; set; }

        public Order() { }
        public Order(int orderId, Customer customer, DateTime orderDate,decimal TotalAmount,string status)
        {
            OrderID = orderId;
            Customer = customer;
            OrderDate = orderDate;
            TotalAmount = 0m;
            Status = status;
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }

}
