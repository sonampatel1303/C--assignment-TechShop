using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.Model
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public Product Product { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime LastStockUpdate { get; set; }

        public Inventory(int inventoryID, Product product, int quantityInStock)
        {
            InventoryID = inventoryID;
            Product = product;
            QuantityInStock = quantityInStock;
            LastStockUpdate = DateTime.Now;
        }
        public override string ToString() => base.ToString();
    }
}
