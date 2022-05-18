using System.Collections.Generic;
using OrderProject.Models;

namespace OrderProject.Data.OutsourcingCompanyData
{
    public interface IOutsourcingCompanyRepo
    {
        IEnumerable<OutsourcingCompany> GetAllOutsourcingCompanies();
        OutsourcingCompany GetOutsourcingCompanyById(int id);
        void CreateCompany(OutsourcingCompany outsourcingCompany);
        void UpdateCompany(OutsourcingCompany outsourcingCompany);
        void DeleteCompany(OutsourcingCompany outsourcingCompany);
    }
}
