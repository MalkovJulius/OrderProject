using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderProject.Models
{
    //Base class
    public class Entity
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
