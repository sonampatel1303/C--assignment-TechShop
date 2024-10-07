using Assignmenttasks.Model;
using Assignmenttasks.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignmenttasks.Repository
{
    public class ProductRepository : iProduct
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public ProductRepository()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnString());
            cmd = new SqlCommand();
        }
        public Product GetProductDetails(int productId)
        {
            string query = "SELECT * FROM Products WHERE ProductID = @ProductID";
            Product product = null;

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                ProductID = (int)reader["ProductID"],
                                ProductName = (string)reader["ProductName"],
                                Description =(string)reader["ProdDescription"],
                                Price = (int)reader["Price"],
                           

                            };
                        }
                    }
                }
            }

            return product;
        }



        // 3. IsProductInStock: Checks if the product is currently in stock.
        public bool IsProductInStock(int productId)
        {
            string query = "SELECT Quantity FROM OrderDetails WHERE ProductID = @ProductID";
            bool isInStock = false;

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    object result = cmd.ExecuteScalar();
                    if (result != null && (int)result > 0)
                    {
                        isInStock = true;
                    }
                }
            }

            return isInStock;
        }

        public bool UpdateProductInfo(int productId, decimal newPrice, string newDescription)
        {
            string query = "UPDATE Products SET Price = @Price, ProdDescription = @Description WHERE ProductID = @ProductID";
            bool isUpdated = false;
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Price", newPrice);
                    cmd.Parameters.AddWithValue("@Description", newDescription);
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0) {
                        isUpdated = true;
                    }
                }
            }
            return isUpdated;
        }


    }
}
