using System.Linq;
using System.Threading.Tasks;
using OrderProject.Models;

namespace OrderProject.Data.CustomerData
{
    public interface ICustomerRepo
    {
        IQueryable<Customer> GetAllCustomers();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);
    }
}
