using Microsoft.EntityFrameworkCore;
using OrderProject.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            await _context.Customers.AddAsync(customer);
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
