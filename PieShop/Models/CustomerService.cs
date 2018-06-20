using System;
using System.Collections.Generic;
using System.Linq;

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

        // Add the database context here add a data through the service
        private readonly PieShopContext _context;

        public CustomerService(PieShopContext pieShopContext)
        {
            _context = pieShopContext;
        }

        // As you can see we keep the structure of the method
        // The return type and the method name and depending on the
        // method if it takes parameters
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customer.ToList();
        }

        public Customer GetCustomerById(int? Id)
        {
            return _context.Customer.FirstOrDefault(c => c.Id == Id);
        }

        public void Save(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();

            Console.WriteLine(customer.Name);
        }
    }


}
