using System.Collections.Generic;
using OrderProject.Models;

namespace OrderProject.Data.ContractorData
{
    public interface IContractorRepo
    {        
        IEnumerable<Contractor> GetAllContractors();
        Contractor GetContractorById(int id);
        void CreateContractor(Contractor command);
        void UpdateContractor(Contractor command);
        void DeleteContractor(Contractor command);
    }
}
