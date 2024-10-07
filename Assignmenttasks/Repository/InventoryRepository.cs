using Assignmenttasks.Model;
using Assignmenttasks.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.Repository
{

    public class InventoryRepository : iInventory
    {

        private List<iInventory> _inventoryList = new List<iInventory>();
        private Product _product;
        private int _quantityInStock;

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public InventoryRepository()
        {
            //sqlConnection = new SqlConnection("Server=DESKTOP-0TE71RT;Database=ProductDb;Trusted_Connection=True");
            sqlConnection = new SqlConnection(DbConnUtil.GetConnString());
            cmd = new SqlCommand();
        }

       
        public InventoryRepository(Product product, int initialStock)
        {
            _product = product;
            _quantityInStock = initialStock;
        }

   
        // GetProduct(): A method to retrieve the product associated with this inventory item.
        public Product GetProduct(int inventoryId)
        {
            string query = "SELECT p.* FROM Inventory i JOIN Products p ON i.ProductID = p.ProductID WHERE i.InventoryID = @InventoryID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@InventoryID", inventoryId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                ProductID = (int)reader["ProductID"],
                                ProductName = (string)reader["ProductName"],
                                Description = (string)reader["ProdDescription"],
                                Price = (int)reader["Price"]
                            };
                        }
                    }
                }
            }
            return null; // Product not found
        }

        // GetQuantityInStock(): A method to get the current quantity of the product in stock.
        public int GetQuantityInStock(int inventoryId)
        {
            string query = "SELECT QuantityInStock FROM Inventory WHERE InventoryID = @InventoryID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                    return (int)cmd.ExecuteScalar(); // Return quantity directly
                }
            }
        }

        // AddToInventory(int quantity): A method to add a specified quantity of the product to the inventory.
        public void AddToInventory(int inventoryId, int quantity)
        {
            string query = "UPDATE Inventory SET QuantityInStock = QuantityInStock + @Quantity WHERE InventoryID = @InventoryID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // RemoveFromInventory(int quantity): A method to remove a specified quantity of the product from the inventory.
        public void RemoveFromInventory(int inventoryId, int quantity)
        {
            string query = "UPDATE Inventory SET QuantityInStock = QuantityInStock - @Quantity WHERE InventoryID = @InventoryID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // UpdateStockQuantity(int newQuantity): A method to update the stock quantity to a new value.
        public void UpdateStockQuantity(int inventoryId, int newQuantity)
        {
            string query = "UPDATE Inventory SET QuantityInStock = @NewQuantity WHERE InventoryID = @InventoryID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
                    cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // IsProductAvailable(int quantityToCheck): A method to check if a specified quantity of the product is available in the inventory.
        public bool IsProductAvailable(int inventoryId, int quantityToCheck)
        {
            int currentStock = GetQuantityInStock(inventoryId);
            return currentStock >= quantityToCheck;
        }

        // GetInventoryValue(): A method to calculate the total value of the products in the inventory based on their prices and quantities.
        public decimal GetInventoryValue(int inventoryId)
        {
            string query = "SELECT p.Price, i.QuantityInStock FROM Inventory i JOIN Products p ON i.ProductID = p.ProductID WHERE i.InventoryID = @InventoryID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int price = (int)reader["Price"];
                            int quantityInStock = (int)reader["QuantityInStock"];
                            return (price * quantityInStock); // Total inventory value
                        }
                    }
                }
            }
            return 0; // No inventory found
        }

        // ListLowStockProducts(int threshold): A method to list products with quantities below a specified threshold, indicating low stock.
        public List<Product> ListLowStockProducts(int threshold)
        {
            List<Product> lowStockProducts = new List<Product>();
            string query = @"
            SELECT p.*
            FROM Inventory i
            JOIN Products p ON i.ProductID = p.ProductID
            WHERE i.QuantityInStock < @Threshold";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Threshold", threshold);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lowStockProducts.Add(new Product
                            {
                                ProductID = (int)reader["ProductID"],
                                ProductName = (string)reader["ProductName"],
                                Description =(string)reader["Description"],
                                Price = (decimal)reader["Price"]
                            });
                        }
                    }
                }
            }

            return lowStockProducts;
        }

        // ListOutOfStockProducts(): A method to list products that are out of stock.
        public List<Product> ListOutOfStockProducts()
        {
            List<Product> outOfStockProducts = new List<Product>();
            string query = @"
            SELECT p.*
            FROM Inventory i
            JOIN Products p ON i.ProductID = p.ProductID
            WHERE i.QuantityInStock = 0";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            outOfStockProducts.Add(new Product
                            {
                                ProductID = (int)reader["ProductID"],
                                ProductName = (string)reader["ProductName"],
                                Description = (string)reader["Description"],
                                Price = (decimal)reader["Price"]
                            });
                        }
                    }
                }
            }

            return outOfStockProducts;
        }
    }


}





