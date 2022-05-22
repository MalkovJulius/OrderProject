using System.Collections.Generic;
using System.ComponentModel;

namespace OrderProject.Models
{
    public class Contractor : Person
    {
        [DisplayName("Orders")]
        public ICollection<Order> Orders { get; set; }
    }
}
