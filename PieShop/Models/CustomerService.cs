using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class CustomerService: ICustomerRepository
    {

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
