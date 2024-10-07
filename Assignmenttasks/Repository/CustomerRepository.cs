using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Numerics;
using Assignmenttasks.Model;
using Assignmenttasks.Repository;
using Assignmenttasks.Utility;

namespace Assignmenttasks.Repository  
{
    public class CustomerRepository : iCustomer
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public CustomerRepository() {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnString());
            cmd = new SqlCommand();
        }
        private List<Customer> customers = new List<Customer>(); 

        public Customer GetCustomerById(int id)
        {
            return customers.Find(c => c.CustomerID == id);
        }
        public void UpdateCustomerInfo(Customer customer)
        {
            var existingCustomer = GetCustomerById(customer.CustomerID);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.Address = customer.Address;
            }
        }
     
        public List<Customer> GetCustomerDetails()
        {
            cmd.CommandText = "select * from Customers";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Customer customer1 = new Customer();
                customer1.CustomerID = (int)reader["CustomerID"];
                customer1.FirstName= (string)reader["FirstName"];
                customer1.LastName = (string)reader["LastName"];
                customer1.Email = (string)reader["Email"];
                customer1.Phone = (long)reader.GetInt32(reader.GetOrdinal("Phone")); 
                customer1.Address = (string)reader["Address"];

                customers.Add(customer1);
            }
            sqlConnection.Close();
            return customers;

        }
        public int CalculateTotalOrders()
        {
            int totalOrders = 0;

            // Use 'using' block to ensure the connection is closed automatically
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("select count(*) as TotalOrders from Orders", sqlConnection))
                {
                    // Use ExecuteScalar to retrieve the single result as an object and cast it to an int
                    totalOrders = (int)cmd.ExecuteScalar();
                }
            }

            return totalOrders;
        }

        public void UpdateCustomerInfo(int customerId, string newEmail, string newPhone, string newAddress)
        {
            string query = "UPDATE Customers SET Email = @Email, Phone = @Phone, Address = @Address WHERE CustomerID = @CustomerID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    // Define parameters and set their values
                    cmd.Parameters.AddWithValue("@Email", newEmail);
                    cmd.Parameters.AddWithValue("@Phone", newPhone);
                    cmd.Parameters.AddWithValue("@Address", newAddress);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) updated.");
                }
            }
        }


    }
}
