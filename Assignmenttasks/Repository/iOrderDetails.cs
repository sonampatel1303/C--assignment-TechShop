using Assignmenttasks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.Repository
{
   public interface iOrderDetails
    {
        decimal CalculateSubtotal(int orderID);
        OrderDetail GetOrderDetailInfo(int orderdetail);
        bool UpdateQuantity(int orderdID, int newQuantity);
        bool AddDiscount(int id,decimal price);
    }
}
