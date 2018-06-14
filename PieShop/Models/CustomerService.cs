using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class CustomerService: ICustomerRepository
    {

        // Our Service uses the ICustomerRepository interface this
        // means that there are certain methods that must be implemented
        // This means that the structure of the method is given to us but
        // what happens inside the method is up to you

        // The Service is also where you would access the database context
        // rather in the Controller

        private List<Customer> _customers;

        public CustomerService()
        {
            InitializeCustomers();
        }

        private void InitializeCustomers()
        {
            _customers = new List<Customer>
            {
                new Customer{Id = 1, Name = "James Dunne", AddressLine1 = "94 Ballytrack", Town = "Letterkenny", County = "Donegal", PostCode = "JT56 F43"},
                new Customer{Id = 1, Name = "Susan Murray", AddressLine1 = "5 Main Street", Town = "Sligo", County = "Sligo", PostCode = "GY6 TR5"},
                new Customer{Id = 1, Name = "John Doe", AddressLine1 = "Hilly", Town = "Ballyhunas", County = "Louth", PostCode = "BS34 UT9"}
            };
        }

        // As you can see we keep the structure of the method
        // The return type and the method name and depending on the
        // method if it takes parameters
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public Customer GetCustomerById(int Id)
        {
            return _customers.FirstOrDefault(c => c.Id == Id);
        }
    }


}
