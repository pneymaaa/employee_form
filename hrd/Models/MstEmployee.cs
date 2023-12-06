using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hrd.Models
{
    public class MstEmployee
    {
        [Key]
        public int ID {get; set;}

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(50, ErrorMessage = "Employee Name must be max 50 chars")]
        [DisplayName("Employee Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address must be max 200 chars")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Religion")]
        public string? ReligionCode { get; set; }
        
        [ForeignKey("ReligionCode")]
        public List<MstReligion>? MstReligions { get; set; }
    }
}