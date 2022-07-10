using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderProject.Dtos;
using OrderProject.Models;

namespace OrderProject.Services.ContractorService
{
    public interface IContractorService
    {
        Task<ContractorDto> GetContractorDtoByIdAsync(int id);
        Task<IEnumerable<ContractorDto>> GetAllContractorsDtosAsync();
        Task CreateContractorAsync(ContractorDto contractorDto);
        Task UpdateContractorAsync(ContractorDto contractorDto);
        Task DeleteContractorAsync(int id);
    }
}
