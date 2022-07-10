using Microsoft.EntityFrameworkCore;
using OrderProject.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<OutsourcingCompany> GetOutsourcingCompanyByIdAsync(int id)
        {
            return await _context.OutsourcingCompanies.FirstOrDefaultAsync(oc => oc.Id == id);
        }

        public async Task CreateCompanyAsync(OutsourcingCompany outsourcingCompany)
        {
            if (outsourcingCompany == null) throw new ArgumentNullException(nameof(outsourcingCompany));
            await _context.OutsourcingCompanies.AddAsync(outsourcingCompany);
        }

        public async Task DeleteCompanyAsync(OutsourcingCompany outsourcingCompany)
        {
            if (outsourcingCompany == null) throw new ArgumentNullException(nameof(outsourcingCompany));
            _context.OutsourcingCompanies.Remove(outsourcingCompany);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompanyAsync(OutsourcingCompany outsourcingCompany)
        {
            if (outsourcingCompany == null) throw new ArgumentNullException(nameof(outsourcingCompany));
            _context.OutsourcingCompanies.Update(outsourcingCompany);
            await _context.SaveChangesAsync();
        }
    }
}
