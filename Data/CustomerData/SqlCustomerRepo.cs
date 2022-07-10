using OrderProject.Models;
using System;
using System.Linq;

namespace OrderProject.Data.CustomerData
{
    public class SqlCustomerRepo : ICustomerRepo
    {
        private readonly Context _context;

        public SqlCustomerRepo(Context context)
        {
            _context = context;
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            return _context.Customers;
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void CreateCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            _context.Customers.Add(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}
