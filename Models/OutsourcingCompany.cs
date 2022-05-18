using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderProject.Models
{
    public class OutsourcingCompany : Entity
    {
        [DisplayName("Employees")]
        public List<Contractor> Employees { get; set; }

        [DisplayName("Orders")]
        public List<Order> Orders { get; set; }
    }
}
