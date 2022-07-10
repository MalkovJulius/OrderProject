﻿using System.Linq;
using OrderProject.Models;

namespace OrderProject.Data.ContractorData
{
    public interface IContractorRepo
    {
        //TODO: make everything asynchronous
        IQueryable<Contractor> GetAllContractors();
        Contractor GetContractorById(int id);
        void CreateContractor(Contractor contractor);
        void UpdateContractor(Contractor contractor);
        void DeleteContractor(Contractor contractor);
    }
}
