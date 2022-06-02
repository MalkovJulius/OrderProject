using System.Linq;
using OrderProject.Models;

namespace OrderProject.Data.OutsourcingCompanyData
{
    public interface IOutsourcingCompanyRepo
    {
        IQueryable<OutsourcingCompany> GetAllOutsourcingCompanies();
        OutsourcingCompany GetOutsourcingCompanyById(int id);
        void CreateCompany(OutsourcingCompany outsourcingCompany);
        void UpdateCompany(OutsourcingCompany outsourcingCompany);
        void DeleteCompany(OutsourcingCompany outsourcingCompany);
    }
}
