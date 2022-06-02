using OrderProject.Models;
using System;
using System.Linq;

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

        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void CreateOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _context.Orders.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _context.Orders.Remove(order);
        }              

        public void UpdateOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
