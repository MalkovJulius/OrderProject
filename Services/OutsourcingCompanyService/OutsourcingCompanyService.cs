using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderProject.Data.OutsourcingCompanyData;
using OrderProject.Dtos;
using OrderProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<OutsourcingCompanyDto> GetOutsourcingCompanyDtoByIdAsync(int id)
        {
            var company = await _companyRepo.GetOutsourcingCompanyByIdAsync(id);
            return company == null ?
                throw new KeyNotFoundException(nameof(company)) :
                _mapper.Map<OutsourcingCompanyDto>(company);
        }

        public async Task<IEnumerable<OutsourcingCompanyDto>> GetAllOutsourcingCompaniesAsync()
        {
            var company = await _companyRepo.GetAllOutsourcingCompanies().ToListAsync();
            return _mapper.Map<IEnumerable<OutsourcingCompanyDto>>(company);
        }

        public async Task CreateCompanyAsync(OutsourcingCompanyDto outsourcingCompanyDto)
        {
            if (outsourcingCompanyDto == null) throw new ArgumentNullException(nameof(outsourcingCompanyDto));

            var company = _mapper.Map<OutsourcingCompany>(outsourcingCompanyDto);
            await _companyRepo.CreateCompanyAsync(company);
        }

        public async Task UpdateCompanyAsync(OutsourcingCompanyDto outsourcingCompanyDto)
        {
            if (outsourcingCompanyDto == null) throw new ArgumentNullException(nameof(outsourcingCompanyDto));

            var company = await _companyRepo.GetOutsourcingCompanyByIdAsync(outsourcingCompanyDto.Id);
            if (company == null) throw new KeyNotFoundException(nameof(company));

            _mapper.Map(outsourcingCompanyDto, company);
            await _companyRepo.UpdateCompanyAsync(company);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            var company = await _companyRepo.GetOutsourcingCompanyByIdAsync(id);
            if (company == null) throw new KeyNotFoundException(nameof(company));

            await _companyRepo.DeleteCompanyAsync(company);
        }
    }
}
