using System.Collections.Generic;
using System.Linq;
using OrderProject.Dtos;
using OrderProject.Models;

namespace OrderProject.Services.OutsourcingCompanyService
{
    public interface IOutsourcingCompanyService
    {
        OutsourcingCompanyDto GetOutsourcingCompanyDtoById(int id);
        IEnumerable<OutsourcingCompanyDto> GetAllOutsourcingCompanies();
        void CreateCompany(OutsourcingCompanyDto outsourcingCompanyDto);
        void UpdateCompany(OutsourcingCompanyDto outsourcingCompanyDto);
        void DeleteCompany(int id);
    }
}
