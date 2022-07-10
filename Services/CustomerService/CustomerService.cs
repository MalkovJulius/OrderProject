using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderProject.Data.CustomerData;
using OrderProject.Dtos;
using OrderProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProject.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<CustomerDto> GetCustomerDtoByIdAsync(int id)
        {
            var customer = await _customerRepo.GetCustomerByIdAsync(id);
            return customer == null ?
                throw new KeyNotFoundException(nameof(customer)):
                _mapper.Map<CustomerDto>(customer);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepo.GetAllCustomers().ToListAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task CreateCustomerAsync(CustomerDto customerDto)
        {
            if (customerDto == null) throw new ArgumentNullException(nameof(customerDto));

            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepo.CreateCustomerAsync(customer);
        }

        public async Task UpdateCustomerAsync(CustomerDto customerDto)
        {
            if (customerDto == null) throw new ArgumentNullException(nameof(customerDto));

            var customer = await _customerRepo.GetCustomerByIdAsync(customerDto.Id);
            if(customer == null) throw new KeyNotFoundException(nameof(customer));

            _mapper.Map(customerDto, customer);
            await _customerRepo.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepo.GetCustomerByIdAsync(id);
            if (customer == null) throw new KeyNotFoundException(nameof(customer));

            await _customerRepo.DeleteCustomerAsync(customer);
        }
    }
}
