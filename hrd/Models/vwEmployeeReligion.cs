using System.ComponentModel;

namespace hrd.Models
{
    public class vwEmployeeReligion
    {
        public int ID { get; set; }
        [DisplayName("Employee Name")]
        public string? Name { get; set; }
        public string? Address { get; set; }
        [DisplayName("Religion Code")]
        public string? ReligionCode { get; set; }
        [DisplayName("Religion Name")]
        public string? ReligionName { get; set; }
    }
}