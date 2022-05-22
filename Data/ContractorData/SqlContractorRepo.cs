using OrderProject.Models;
using System.Collections.Generic;

namespace OrderProject.Data.ContractorData
{
    public class SqlContractorRepo : IContractorRepo
    {
        private readonly Context _context;

        public SqlContractorRepo(Context context)
        {
            _context = context;
        }

        public void CreateContractor(Contractor command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteContractor(Contractor command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Contractor> GetAllContractors()
        {
            throw new System.NotImplementedException();
        }

        public Contractor GetContractorById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateContractor(Contractor command)
        {
            throw new System.NotImplementedException();
        }
    }
}
