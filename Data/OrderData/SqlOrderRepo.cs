using Microsoft.EntityFrameworkCore;
using OrderProject.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProject.Data.OrderData
{
    public class SqlOrderRepo : IOrderRepo
    {
        private readonly Context _context;

        public SqlOrderRepo(Context context)
        {
            _context = context;
        }

        public IQueryable<Order> GetAllOrders()
        {
            return _context.Orders;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task CreateOrderAsync(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            await _context.Orders.AddAsync(order);
        }

        public async Task DeleteOrderAsync(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }              

        public async Task UpdateOrderAsync(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
