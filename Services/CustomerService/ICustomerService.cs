using System.Collections.Generic;
using System.Linq;
using OrderProject.Dtos;
using OrderProject.Models;

namespace OrderProject.Services.CustomerService
{
    public interface ICustomerService
    {
        CustomerDto GetCustomerDtoById(int id);
        IEnumerable<CustomerDto> GetAllCustomers();
        void CreateCustomer(CustomerDto customerDto);
        void UpdateCustomer(CustomerDto customerDto);
        void DeleteCustomer(int id);
    }
}
