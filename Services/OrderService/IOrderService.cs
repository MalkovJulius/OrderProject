using System.Collections.Generic;
using System.Linq;
using OrderProject.Dtos;
using OrderProject.Models;

namespace OrderProject.Services.OrderService
{
    public interface IOrderService
    {
        OrderDto GetOrderDtoById(int id);
        IEnumerable<OrderDto> GetAllOrders();
        void CreateOrder(OrderDto orderDto);
        void UpdateOrder(OrderDto orderDto);
        void DeleteOrder(int id);
    }
}
