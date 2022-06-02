using System.Linq;
using OrderProject.Models;

namespace OrderProject.Data.OrderData
{
    public interface IOrderRepo
    {
        IQueryable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
