using AutoMapper;
using OrderProject.Dtos;
using OrderProject.Models;

namespace OrderProject.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            //target -> source
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}
