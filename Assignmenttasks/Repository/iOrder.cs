using Assignmenttasks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.Repository
{
    public interface iOrder
    {
       decimal CalculateTotalAmount(int order);
        (Order, List<Product>) GetOrderDetails(int id);
        bool UpdateOrderStatus(int order, string newStatus);
        bool CancelOrder(int orderId);
    }
}
