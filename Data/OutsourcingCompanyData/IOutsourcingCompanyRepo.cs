using System.Linq;
using OrderProject.Models;

namespace OrderProject.Data.OutsourcingCompanyData
{
    public interface IOutsourcingCompanyRepo
    {
        //TODO: make everything asynchronous
        IQueryable<OutsourcingCompany> GetAllOutsourcingCompanies();
        OutsourcingCompany GetOutsourcingCompanyById(int id);
        //async Task CreateCompanyAsync(OutsourcingCompany outsourcingCompany); 
        void CreateCompany(OutsourcingCompany outsourcingCompany);
        void UpdateCompany(OutsourcingCompany outsourcingCompany);
        void DeleteCompany(OutsourcingCompany outsourcingCompany);
    }
}
