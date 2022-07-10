using System.Collections.Generic;
using System.Linq;
using OrderProject.Dtos;
using OrderProject.Models;

namespace OrderProject.Services.ContractorService
{
    public interface IContractorService
    {
        ContractorDto GetContractorDtoById(int id);
        IEnumerable<ContractorDto> GetAllContractorsDtos();
        void CreateContractor(ContractorDto contractorDto);
        void UpdateContractor(ContractorDto contractorDto);
        void DeleteContractor(int id);
    }
}
