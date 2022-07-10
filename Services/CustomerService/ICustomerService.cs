using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderProject.Dtos;
using OrderProject.Models;

namespace OrderProject.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerDtoByIdAsync(int id);
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task CreateCustomerAsync(CustomerDto customerDto);
        Task UpdateCustomerAsync(CustomerDto customerDto);
        Task DeleteCustomerAsync(int id);
    }
}
