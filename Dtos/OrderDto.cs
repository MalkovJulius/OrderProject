using System.Collections.Generic;

namespace OrderProject.Dtos
{
    /// <summary>
    /// Dto is for creating Order
    /// </summary>
    public class OrderDto : BaseDto
    {
        public string Description { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public IEnumerable<ContractorDto> Contractors { get; set; }
    }
}
