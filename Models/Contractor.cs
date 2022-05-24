using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderProject.Models
{
    public class Contractor : Person
    {
        [Required]
        [DisplayName("Company")]
        public OutsourcingCompany Company { get; set; }

        [DisplayName("Order")]
        public Order Order { get; set; }
    }
}
