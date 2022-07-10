using System.Linq;
using OrderProject.Models;

namespace OrderProject.Data.OrderData
{
    public interface IOrderRepo
    {
        //TODO: make everything asynchronous
        IQueryable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
