using Assignmenttasks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.Repository
{
  public interface iProduct
    {
        bool UpdateProductInfo(int product, decimal price,string description);
       bool IsProductInStock(int product);

        Product GetProductDetails(int product);
    }
}
