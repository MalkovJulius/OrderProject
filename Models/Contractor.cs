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

        [Required]
        [DisplayName("Position")]
        public Position Position { get; set; }
    }

    public enum Position
    {
        Manager = 10,
        Developer = 20,
        QA = 30,
        Analytic = 40
    }
}
