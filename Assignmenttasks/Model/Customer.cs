using Assignmenttasks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.Model
{
    public class Customer
    {

        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }





        public Customer(int customerId, string firstName, string lastName, string email, long phone, string address)
        {
            CustomerID = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;

        }

        public Customer()
        {
        }
        public override string ToString()
        {
            return $"Customer id :{CustomerID},Name: {FirstName} {LastName},Email is {Email}, Phone: {Phone} Address is{Address}";
        }


    }

}

