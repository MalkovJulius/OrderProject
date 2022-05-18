using System.Collections.Generic;
using OrderProject.Models;

namespace OrderProject.Data.OrderData
{
    public interface IOrderRepo
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order command);
        void UpdateOrder(Order command);
        void DeleteOrder(Order command);
    }
}
