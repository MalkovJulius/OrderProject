using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderProject.Models
{
    public class Person : Entity
    {
        [Required]
        [StringLength(250)]
        [DisplayName("Surname")]
        public string Surname { get; set; }
    }
}
