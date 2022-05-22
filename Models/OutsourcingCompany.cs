using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderProject.Models
{
    public class OutsourcingCompany : Entity
    {
        [DisplayName("Employees")]
        public ICollection<Contractor> Employees { get; set; }

        [DisplayName("Orders")]
        public ICollection<Order> Orders { get; set; }
    }
}
