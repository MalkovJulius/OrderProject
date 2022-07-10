using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderProject.Data.ContractorData;
using OrderProject.Dtos;
using OrderProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProject.Services.ContractorService
{
    public class ContractorService : IContractorService
    {
        private readonly IContractorRepo _contractorRepo;
        private readonly IMapper _mapper;

        public ContractorService(IContractorRepo contractorRepo, IMapper mapper)
        {
            _contractorRepo = contractorRepo;
            _mapper = mapper;
        }

        public async Task<ContractorDto> GetContractorDtoByIdAsync(int id)
        {
            var contractor = await _contractorRepo.GetContractorByIdAsync(id);
            return contractor == null?
                throw new KeyNotFoundException(nameof(contractor)):
                _mapper.Map<ContractorDto>(contractor);
        }

        public async Task<IEnumerable<ContractorDto>> GetAllContractorsDtosAsync()
        {
            //TODO: make pagination and other add-ons here and other services
            var contractors = await _contractorRepo.GetAllContractors().ToListAsync();
            return _mapper.Map<IEnumerable<ContractorDto>>(contractors);
        }

        public async Task CreateContractorAsync(ContractorDto contractorDto)
        {
            if (contractorDto == null) throw new ArgumentNullException(nameof(contractorDto));

            var contactor = _mapper.Map<Contractor>(contractorDto);
            await _contractorRepo.CreateContractorAsync(contactor);
        }

        public async Task UpdateContractorAsync(ContractorDto contractorDto)
        {
            if (contractorDto == null) throw new ArgumentNullException(nameof(contractorDto));
            
            var contractor = await _contractorRepo.GetContractorByIdAsync(contractorDto.Id);
            if (contractor == null) throw new KeyNotFoundException(nameof(contractor));

            _mapper.Map(contractorDto, contractor);
            await _contractorRepo.UpdateContractorAsync(contractor);
        }

        public async Task DeleteContractorAsync(int id)
        {
            var contractor = await _contractorRepo.GetContractorByIdAsync(id);
            if (contractor == null) throw new KeyNotFoundException(nameof(contractor));

            await _contractorRepo.DeleteContractorAsync(contractor);         
        }
    }
}
