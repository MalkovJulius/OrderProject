using System.Collections.Generic;
using OrderProject.Models;

namespace OrderProject.Data.CustomerData
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer command);
        void UpdateCustomer(Customer command);
        void DeleteCustomer(Customer command);
    }
}
