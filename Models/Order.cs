using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderProject.Models
{
    public class Order : Entity
    {
        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Contractors")]
        public ICollection<Contractor> Contractors { get; set; }

        [Required]
        [DisplayName("Customer")]
        public Customer Customer { get; set; }
    }
}
