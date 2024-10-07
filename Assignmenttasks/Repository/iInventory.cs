using Assignmenttasks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.Repository
{
 public interface iInventory
    {
        Product GetProduct(int inventoryId); // Get product associated with inventory
        int GetQuantityInStock(int inventoryId); // Get current quantity in stock
        void AddToInventory(int inventoryId, int quantity); // Add specified quantity to inventory
        void RemoveFromInventory(int inventoryId, int quantity); // Remove specified quantity from inventory
        void UpdateStockQuantity(int inventoryId, int newQuantity); // Update stock quantity to a new value
        bool IsProductAvailable(int inventoryId, int quantityToCheck); // Check if a specified quantity is available
        decimal GetInventoryValue(int inventoryId); // Calculate the total value of products in inventory
        List<Product> ListLowStockProducts(int threshold); // List products below a stock threshold
        List<Product> ListOutOfStockProducts(); // List out of stock products

       
    }
}
