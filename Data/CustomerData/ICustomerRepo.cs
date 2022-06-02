using System.Linq;
using OrderProject.Models;

namespace OrderProject.Data.CustomerData
{
    public interface ICustomerRepo
    {
        IQueryable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
