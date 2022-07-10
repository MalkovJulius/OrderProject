using OrderProject.Models;
using System;
using System.Linq;

namespace OrderProject.Data.OutsourcingCompanyData
{
    public class SqlOutsourcingCompanyRepo : IOutsourcingCompanyRepo
    {
        private readonly Context _context;

        public SqlOutsourcingCompanyRepo(Context context)
        {
            _context = context;
        }
        public IQueryable<OutsourcingCompany> GetAllOutsourcingCompanies()
        {
            return _context.OutsourcingCompanies;
        }

        public OutsourcingCompany GetOutsourcingCompanyById(int id)
        {
            return _context.OutsourcingCompanies.FirstOrDefault(oc => oc.Id == id);
        }

        public void CreateCompany(OutsourcingCompany outsourcingCompany)
        {
            if (outsourcingCompany == null) throw new ArgumentNullException(nameof(outsourcingCompany));
            _context.OutsourcingCompanies.Add(outsourcingCompany);
        }

        public void DeleteCompany(OutsourcingCompany outsourcingCompany)
        {
            if (outsourcingCompany == null) throw new ArgumentNullException(nameof(outsourcingCompany));
            _context.OutsourcingCompanies.Remove(outsourcingCompany);
            _context.SaveChanges();
        }

        public void UpdateCompany(OutsourcingCompany outsourcingCompany)
        {
            if (outsourcingCompany == null) throw new ArgumentNullException(nameof(outsourcingCompany));
            _context.OutsourcingCompanies.Update(outsourcingCompany);
            _context.SaveChanges();
        }
    }
}
