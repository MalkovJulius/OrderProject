using OrderProject.Models;
using System;
using System.Linq;

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

        public Contractor GetContractorById(int id)
        {
            return _context.Contractors.FirstOrDefault(c => c.Id == id);
        }

        public void CreateContractor(Contractor contractor)
        {
            if (contractor == null) throw new ArgumentNullException(nameof(contractor));
            _context.Contractors.Add(contractor);
        }

        public void DeleteContractor(Contractor contractor)
        {
            if (contractor == null) throw new ArgumentNullException(nameof(contractor));
            _context.Contractors.Remove(contractor);
        }        

        public void UpdateContractor(Contractor contractor)
        {
            if (contractor == null) throw new ArgumentNullException(nameof(contractor));
            _context.Contractors.Update(contractor);
            _context.SaveChanges();
        }
    }
}
