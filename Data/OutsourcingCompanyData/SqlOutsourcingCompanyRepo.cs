using OrderProject.Models;
using System.Collections.Generic;

namespace OrderProject.Data.OutsourcingCompanyData
{
    public class SqlOutsourcingCompanyRepo : IOutsourcingCompanyRepo
    {
        private readonly Context _context;

        public SqlOutsourcingCompanyRepo(Context context)
        {
            _context = context;
        }

        public void CreateCompany(OutsourcingCompany outsourcingCompany)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCompany(OutsourcingCompany outsourcingCompany)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<OutsourcingCompany> GetAllOutsourcingCompanies()
        {
            throw new System.NotImplementedException();
        }

        public OutsourcingCompany GetOutsourcingCompanyById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCompany(OutsourcingCompany outsourcingCompany)
        {
            throw new System.NotImplementedException();
        }
    }
}
