using AutoMapper;
using OrderProject.Dtos;
using OrderProject.Models;

namespace OrderProject.Profiles
{
    public class ContractorProfile : Profile
    {
        public ContractorProfile()
        {
            //target -> source
            CreateMap<Contractor, ContractorDto>();
            CreateMap<ContractorDto, Contractor>();
        }
    }
}
