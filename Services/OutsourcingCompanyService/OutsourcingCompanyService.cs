using AutoMapper;
using OrderProject.Data.OutsourcingCompanyData;
using OrderProject.Dtos;
using OrderProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderProject.Services.OutsourcingCompanyService
{
    public class OutsourcingCompanyService : IOutsourcingCompanyService
    {
        private readonly IOutsourcingCompanyRepo _companyRepo;
        private readonly IMapper _mapper;

        public OutsourcingCompanyService(IOutsourcingCompanyRepo companyRepo, IMapper mapper)
        {
            _companyRepo = companyRepo;
            _mapper = mapper;
        }

        public OutsourcingCompanyDto GetOutsourcingCompanyDtoById(int id)
        {
            var company = _companyRepo.GetOutsourcingCompanyById(id);
            return company == null ?
                throw new KeyNotFoundException(nameof(company)) :
                _mapper.Map<OutsourcingCompanyDto>(company);
        }

        public IEnumerable<OutsourcingCompanyDto> GetAllOutsourcingCompanies()
        {
            var company = _companyRepo.GetAllOutsourcingCompanies();
            return _mapper.Map<IEnumerable<OutsourcingCompanyDto>>(company);
        }

        public void CreateCompany(OutsourcingCompanyDto outsourcingCompanyDto)
        {
            if (outsourcingCompanyDto == null) throw new ArgumentNullException(nameof(outsourcingCompanyDto));

            var company = _mapper.Map<OutsourcingCompany>(outsourcingCompanyDto);
            _companyRepo.CreateCompany(company);
        }

        public void UpdateCompany(OutsourcingCompanyDto outsourcingCompanyDto)
        {
            if (outsourcingCompanyDto == null) throw new ArgumentNullException(nameof(outsourcingCompanyDto));

            var company = _companyRepo.GetOutsourcingCompanyById(outsourcingCompanyDto.Id);
            if (company == null) throw new KeyNotFoundException(nameof(company));

            _mapper.Map(outsourcingCompanyDto, company);
            _companyRepo.UpdateCompany(company);
        }

        public void DeleteCompany(int id)
        {
            var company = _companyRepo.GetOutsourcingCompanyById(id);
            if (company == null) throw new KeyNotFoundException(nameof(company));

            _companyRepo.DeleteCompany(company);
        }
    }
}
