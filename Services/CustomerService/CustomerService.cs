using AutoMapper;
using OrderProject.Data.CustomerData;
using OrderProject.Dtos;
using OrderProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public CustomerDto GetCustomerDtoById(int id)
        {
            var customer = _customerRepo.GetCustomerById(id);
            return customer == null ?
                throw new KeyNotFoundException(nameof(customer)):
                _mapper.Map<CustomerDto>(customer);
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var customers = _customerRepo.GetAllCustomers();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public void CreateCustomer(CustomerDto customerDto)
        {
            if (customerDto == null) throw new ArgumentNullException(nameof(customerDto));

            var customer = _mapper.Map<Customer>(customerDto);
            _customerRepo.CreateCustomer(customer);
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            if (customerDto == null) throw new ArgumentNullException(nameof(customerDto));

            var customer = _customerRepo.GetCustomerById(customerDto.Id);
            if(customer == null) throw new KeyNotFoundException(nameof(customer));

            _mapper.Map(customerDto, customer);
            _customerRepo.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            var customer = _customerRepo.GetCustomerById(id);
            if (customer == null) throw new KeyNotFoundException(nameof(customer));

            _customerRepo.DeleteCustomer(customer);
        }
    }
}
