using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderProject.Data.OrderData;
using OrderProject.Dtos;
using OrderProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProject.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepo orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task<OrderDto> GetOrderDtoByIdAsync(int id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);
            return order == null ?
                throw new KeyNotFoundException(nameof(order)) :
                _mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepo.GetAllOrders().ToListAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task CreateOrderAsync(OrderDto orderDto)
        {
            if (orderDto == null) throw new ArgumentNullException(nameof(orderDto));

            var order = _mapper.Map<Order>(orderDto);
            await _orderRepo.CreateOrderAsync(order);
        }

        public async Task UpdateOrderAsync(OrderDto orderDto)
        {
            if (orderDto == null) throw new ArgumentNullException(nameof(orderDto));

            var order = await _orderRepo.GetOrderByIdAsync(orderDto.Id);
            if (order == null) throw new KeyNotFoundException(nameof(order));

            _mapper.Map(orderDto, order);
            await _orderRepo.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);
            if (order == null) throw new KeyNotFoundException(nameof(order));

            await _orderRepo.DeleteOrderAsync(order);
        }
    }
}
