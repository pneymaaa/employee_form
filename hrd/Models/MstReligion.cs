using System.ComponentModel.DataAnnotations;

namespace hrd.Models
{
    public class MstReligion
    {
        [Key]
        public required string Code {get; set;}
        public string? Name { get; set; }
        public List<MstEmployee>? MstEmployees { get; set; }
    }
}