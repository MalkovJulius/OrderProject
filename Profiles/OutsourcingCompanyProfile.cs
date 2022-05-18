using AutoMapper;
using OrderProject.Dtos;
using OrderProject.Models;

namespace OrderProject.Profiles
{
    public class OutsourcingCompanyProfile : Profile
    {
        public OutsourcingCompanyProfile()
        {
            //target -> source
            CreateMap<OutsourcingCompany, OutsourcingCompanyDto>();
            CreateMap<OutsourcingCompanyDto, OutsourcingCompany>();
        }
    }
}
