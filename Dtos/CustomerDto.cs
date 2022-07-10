using System.Collections.Generic;

namespace OrderProject.Dtos
{
    /// <summary>
    /// Dto is for creating Customer
    /// </summary>
    public class CustomerDto : BaseDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        //public IEnumerable<OrderDto> Orders { get; set; }
    }
}
