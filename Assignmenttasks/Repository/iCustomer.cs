using Assignmenttasks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.Repository
{
    public interface iCustomer
    {
       int CalculateTotalOrders();
        void UpdateCustomerInfo(Customer customer);

      List<Customer> GetCustomerDetails();
    }
}
