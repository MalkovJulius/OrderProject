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
            return _context.OutsourcingCompanyes;
        }

        public OutsourcingCompany GetOutsourcingCompanyById(int id)
        {
            return _context.OutsourcingCompanyes.FirstOrDefault(oc => oc.Id == id);
        }

        public void CreateCompany(OutsourcingCompany outsourcingCompany)
        {
            if (outsourcingCompany == null) throw new ArgumentNullException(nameof(outsourcingCompany));
            _context.OutsourcingCompanyes.Add(outsourcingCompany);
        }

        public void DeleteCompany(OutsourcingCompany outsourcingCompany)
        {
            if (outsourcingCompany == null) throw new ArgumentNullException(nameof(outsourcingCompany));
            _context.OutsourcingCompanyes.Remove(outsourcingCompany);
        }

        public void UpdateCompany(OutsourcingCompany outsourcingCompany)
        {
            if (outsourcingCompany == null) throw new ArgumentNullException(nameof(outsourcingCompany));
            _context.OutsourcingCompanyes.Update(outsourcingCompany);
            _context.SaveChanges();
        }
    }
}
