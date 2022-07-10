using AutoMapper;
using OrderProject.Data.ContractorData;
using OrderProject.Dtos;
using OrderProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public ContractorDto GetContractorDtoById(int id)
        {
            var contractor = _contractorRepo.GetContractorById(id);
            return contractor == null?
                throw new KeyNotFoundException(nameof(contractor)):
                _mapper.Map<ContractorDto>(contractor);
        }

        public IEnumerable<ContractorDto> GetAllContractorsDtos()
        {
            var contractors = _contractorRepo.GetAllContractors();
            return _mapper.Map<IEnumerable<ContractorDto>>(contractors);
        }

        public void CreateContractor(ContractorDto contractorDto)
        {
            if (contractorDto == null) throw new ArgumentNullException(nameof(contractorDto));

            var contactor = _mapper.Map<Contractor>(contractorDto);
            _contractorRepo.CreateContractor(contactor);
        }     

        public void UpdateContractor(ContractorDto contractorDto)
        {
            if (contractorDto == null) throw new ArgumentNullException(nameof(contractorDto));
            
            var contractor = _contractorRepo.GetContractorById(contractorDto.Id);
            if (contractor == null) throw new KeyNotFoundException(nameof(contractor));

            _mapper.Map(contractorDto, contractor);
            _contractorRepo.UpdateContractor(contractor);
        }

        public void DeleteContractor(int id)
        {
            var contractor = _contractorRepo.GetContractorById(id);
            if (contractor == null) throw new KeyNotFoundException(nameof(contractor));

            _contractorRepo.DeleteContractor(contractor);         
        }
    }
}
