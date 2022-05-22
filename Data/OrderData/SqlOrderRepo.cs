using OrderProject.Models;
using System.Collections.Generic;

namespace OrderProject.Data.OrderData
{
    public class SqlOrderRepo : IOrderRepo
    {
        private readonly Context _context;

        public SqlOrderRepo(Context context)
        {
            _context = context;
        }

        public void CreateOrder(Order command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteOrder(Order command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            throw new System.NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOrder(Order command)
        {
            throw new System.NotImplementedException();
        }
    }
}
