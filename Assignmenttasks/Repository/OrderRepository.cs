using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Assignmenttasks.Model;
using Assignmenttasks.Utility;

namespace Assignmenttasks.Repository
{
    public class OrderRepository : iOrder
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public OrderRepository()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnString());
            cmd = new SqlCommand();
        }
        private List<Order> orders = new List<Order>();  // In-memory list to store orders

        public decimal CalculateTotalAmount(int orderId)
        {
            decimal totalAmount = 0;
            string query = "SELECT TotalAmount FROM Orders WHERE OrderID = @OrderID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    totalAmount = (int)cmd.ExecuteScalar();
                }
            }

            return totalAmount;
        }

        public (Order, List<Product>) GetOrderDetails(int orderId)
        {
            Order order = null;
            List<Product> products = new List<Product>();

            string orderQuery = "SELECT OrderID, CustomerID, OrderDate, TotalAmount FROM Orders WHERE OrderID = @OrderID";
            string productQuery = @"
        SELECT p.ProductID, p.ProductName, p.ProdDescription, od.Quantity, p.Price
        FROM OrderDetails od
        JOIN Products p ON od.ProductID = p.ProductID
        WHERE od.OrderID = @OrderID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
              sqlConnection.Open();

                // Fetch Order Details
                using (SqlCommand orderCmd = new SqlCommand(orderQuery, sqlConnection))
                {
                    orderCmd.Parameters.AddWithValue("@OrderID", orderId);

                    using (SqlDataReader reader = orderCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order = new Order
                            {
                                OrderID = orderId,
                                Customer = new Customer { CustomerID = (int)reader["CustomerID"] },
                                OrderDate = (DateTime)reader["OrderDate"],
                                TotalAmount = (int)reader["TotalAmount"]
                            };
                        }
                    }
                }

                // Fetch Product Details for the Order
                using (SqlCommand productCmd = new SqlCommand(productQuery, sqlConnection))
                {
                    productCmd.Parameters.AddWithValue("@OrderID", orderId);

                    using (SqlDataReader reader = productCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductID = (int)reader["ProductID"],
                                ProductName = (string)reader["ProductName"],
                                Description = (string)reader["ProdDescription"],
                                Price = (int)reader["Price"]
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return (order, products);
        }
        public bool UpdateOrderStatus(int orderId, string newStatus)
        {
            string query = "UPDATE Orders SET OrderStatus = @Status WHERE OrderID = @OrderID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@OrderID", orderId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if the update was successful
                }
            }
        }

        public bool CancelOrder(int orderId)
        {
            // First, retrieve the product quantities in the order
            List<(int ProductID, int Quantity)> productsToRestore = new List<(int, int)>();

            string selectQuery = "SELECT ProductID, Quantity FROM OrderDetails WHERE OrderID = @OrderID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand(selectQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int productId = (int)reader["ProductID"];
                            int quantity = (int)reader["Quantity"];
                            productsToRestore.Add((productId, quantity));
                        }
                    }
                }

                // Restore stock levels for each product in the order
                foreach (var order in productsToRestore)
                {
                    string updateStockQuery = "UPDATE OrderDetails SET Quantity = Quantity + @Quantity WHERE ProductID = @ProductID";

                    using (SqlCommand cmd = new SqlCommand(updateStockQuery, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", order.Quantity);
                        cmd.Parameters.AddWithValue("@ProductID", order.ProductID);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Now, delete the order
                string deleteOrderQuery = "DELETE FROM Orders WHERE OrderID = @OrderID";

                using (SqlCommand cmd = new SqlCommand(deleteOrderQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if the order was successfully canceled
                }
            }
        }

    }
}
