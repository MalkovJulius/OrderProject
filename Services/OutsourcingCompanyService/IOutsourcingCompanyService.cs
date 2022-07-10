using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderProject.Dtos;
using OrderProject.Models;

namespace OrderProject.Services.OutsourcingCompanyService
{
    public interface IOutsourcingCompanyService
    {
        Task<OutsourcingCompanyDto> GetOutsourcingCompanyDtoByIdAsync(int id);
        Task<IEnumerable<OutsourcingCompanyDto>> GetAllOutsourcingCompaniesAsync();
        Task CreateCompanyAsync(OutsourcingCompanyDto outsourcingCompanyDto);
        Task UpdateCompanyAsync(OutsourcingCompanyDto outsourcingCompanyDto);
        Task DeleteCompanyAsync(int id);
    }
}
