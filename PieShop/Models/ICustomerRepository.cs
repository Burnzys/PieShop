using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public interface ICustomerRepository
    {
        // An interface allows us to access behavior that we
        // wish to implement in another class.

        // For our CustomerService we wish it to incude the methods
        // for getting all the customers and also a single customer using
        // their ID

        // If we wished to add more access methods we would add them
        // here and then they would have to be implemented within the
        // class that uses the interface

        // The structure for an interface method is slightly
        // different from a normal method we just have a retrun type,
        // the name, it it takes parameters, no curly braces and ends with
        // a semi-colen
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int Id);
    }
}
