using OrderProject.Models;
using System.Collections.Generic;

namespace OrderProject.Data.CustomerData
{
    public class SqlCustomerRepo : ICustomerRepo
    {
        private readonly Context _context;

        public SqlCustomerRepo(Context context)
        {
            _context = context;
        }

        public void CreateCustomer(Customer command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCustomer(Customer command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCustomer(Customer command)
        {
            throw new System.NotImplementedException();
        }
    }
}
