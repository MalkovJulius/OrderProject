using AutoMapper;
using OrderProject.Data.OrderData;
using OrderProject.Dtos;
using OrderProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public OrderDto GetOrderDtoById(int id)
        {
            var order = _orderRepo.GetOrderById(id);
            return order == null ?
                throw new KeyNotFoundException(nameof(order)) :
                _mapper.Map<OrderDto>(order);
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            var orders = _orderRepo.GetAllOrders();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public void CreateOrder(OrderDto orderDto)
        {
            if (orderDto == null) throw new ArgumentNullException(nameof(orderDto));

            var order = _mapper.Map<Order>(orderDto);
            _orderRepo.CreateOrder(order);
        }             

        public void UpdateOrder(OrderDto orderDto)
        {
            if (orderDto == null) throw new ArgumentNullException(nameof(orderDto));

            var order = _orderRepo.GetOrderById(orderDto.Id);
            if (order == null) throw new KeyNotFoundException(nameof(order));

            _mapper.Map(orderDto, order);
            _orderRepo.UpdateOrder(order);
        }

        public void DeleteOrder(int id)
        {
            var order = _orderRepo.GetOrderById(id);
            if (order == null) throw new KeyNotFoundException(nameof(order));

            _orderRepo.DeleteOrder(order);
        }
    }
}
