using Microsoft.EntityFrameworkCore;
using OrderProject.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProject.Data.ContractorData
{
    public class SqlContractorRepo : IContractorRepo
    {
        private readonly Context _context;

        public SqlContractorRepo(Context context)
        {
            _context = context;
        }

        public IQueryable<Contractor> GetAllContractors()
        {
            return _context.Contractors;
        }

        public async Task<Contractor> GetContractorByIdAsync(int id)
        {
            return await _context.Contractors.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateContractorAsync(Contractor contractor)
        {
            if (contractor == null) throw new ArgumentNullException(nameof(contractor));
            await _context.Contractors.AddAsync(contractor);
        }

        public async Task DeleteContractorAsync(Contractor contractor)
        {
            if (contractor == null) throw new ArgumentNullException(nameof(contractor));
            _context.Contractors.Remove(contractor);
            await _context.SaveChangesAsync();
        }        

        public async Task UpdateContractorAsync(Contractor contractor)
        {
            if (contractor == null) throw new ArgumentNullException(nameof(contractor));
            _context.Contractors.Update(contractor);
            await _context.SaveChangesAsync();
        }
    }
}
