using System.Collections.Generic;

namespace OrderProject.Dtos
{
    /// <summary>
    /// Dto is for creating OutsourcingCompany
    /// </summary>
    public class OutsourcingCompanyDto : BaseDto
    {
        public string Name { get; set; }

        //public IEnumerable<ContractorDto> Contractors { get; set; } 
    }
}
