using System.Collections.Generic;
using System.ComponentModel;

namespace OrderProject.Models
{
    public class Contractor : Person
    {
        [DisplayName("Orders")]
        public List<Order> Orders { get; set; }
    }
}
