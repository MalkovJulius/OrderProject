using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderProject.Dtos;
using OrderProject.Models;

namespace OrderProject.Services.OrderService
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderDtoByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task CreateOrderAsync(OrderDto orderDto);
        Task UpdateOrderAsync(OrderDto orderDto);
        Task DeleteOrderAsync(int id);
    }
}
