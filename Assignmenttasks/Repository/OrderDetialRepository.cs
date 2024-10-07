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
    public class OrderDetialRepository : iOrderDetails
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public OrderDetialRepository()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnString());
            cmd = new SqlCommand();
        }
      
        public bool UpdateQuantity(int orderDetailId, int newQuantity)
        {
            string query = "UPDATE OrderDetails SET Quantity = @Quantity WHERE OrderDetailID = @OrderDetailID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                    cmd.Parameters.AddWithValue("@OrderDetailID", orderDetailId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if the update was successful
                }
            }
        }
        public bool AddDiscount(int productID, decimal discountAmount)
        {
            string query = "UPDATE Products SET Price = Price-@Discount WHERE ProductID = @productID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Discount", discountAmount);
                    cmd.Parameters.AddWithValue("@productID", productID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if the discount was applied successfully
                }
            }
        }

        public OrderDetail GetOrderDetailInfo(int orderDetailId)
        {
            string query = "SELECT od.OrderDetailID, od.ProductID, p.ProductName, od.Quantity,p.Price " +
                           "FROM OrderDetails od " +
                           "JOIN Products p ON od.ProductID = p.ProductID " +
                           "WHERE od.OrderDetailID = @OrderDetailID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@OrderDetailID", orderDetailId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the OrderDetail object
                            OrderDetail orderDetail = new OrderDetail
                            {
                                OrderDetailID = (int)reader["OrderDetailID"],
                                
                                Quantity = (int)reader["Quantity"]
                              
                            };
                            return orderDetail;
                        }
                    }
                }
            }

            return null; // Return null if not found
        }
        public decimal CalculateSubtotal(int orderDetailId)
        {
            string query = @"
        SELECT od.Quantity, p.Price 
        FROM OrderDetails od JOIN Products p
        ON od.ProductID = p.ProductID WHERE od.orderDetailID=@orderDetailID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@OrderDetailID", orderDetailId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Directly calculate the subtotal
                            int quantity = (int)reader["Quantity"];
                            decimal price = (int)reader["Price"];
                            //decimal discount = (decimal)reader["Discount"];

                            return (price * quantity); // Calculate and return the subtotal
                        }
                    }
                }
            }

            throw new Exception("Order detail not found."); // Handle the case where the order detail does not exist
        }


    }
}
