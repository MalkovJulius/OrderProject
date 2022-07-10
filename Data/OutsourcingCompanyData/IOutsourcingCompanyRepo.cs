using System.Linq;
using System.Threading.Tasks;
using OrderProject.Models;

namespace OrderProject.Data.OutsourcingCompanyData
{
    public interface IOutsourcingCompanyRepo
    {
        IQueryable<OutsourcingCompany> GetAllOutsourcingCompanies();
        Task<OutsourcingCompany> GetOutsourcingCompanyByIdAsync(int id);
        Task CreateCompanyAsync(OutsourcingCompany outsourcingCompany);
        Task UpdateCompanyAsync(OutsourcingCompany outsourcingCompany);
        Task DeleteCompanyAsync(OutsourcingCompany outsourcingCompany);
    }
}
