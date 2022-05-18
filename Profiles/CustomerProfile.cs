using AutoMapper;
using OrderProject.Dtos;
using OrderProject.Models;

namespace OrderProject.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //target -> source
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
