using System.Linq;
using System.Threading.Tasks;
using OrderProject.Models;

namespace OrderProject.Data.ContractorData
{
    public interface IContractorRepo
    {
        IQueryable<Contractor> GetAllContractors();
        Task<Contractor> GetContractorByIdAsync(int id);
        Task CreateContractorAsync(Contractor contractor);
        Task UpdateContractorAsync(Contractor contractor);
        Task DeleteContractorAsync(Contractor contractor);
    }
}
