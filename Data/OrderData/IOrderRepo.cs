using System.Linq;
using System.Threading.Tasks;
using OrderProject.Models;

namespace OrderProject.Data.OrderData
{
    public interface IOrderRepo
    {
        IQueryable<Order> GetAllOrders();
        Task<Order> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
    }
}
