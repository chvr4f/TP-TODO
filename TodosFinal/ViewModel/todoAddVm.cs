using System.ComponentModel.DataAnnotations;
using TodosFinal.Enums;

namespace TodosFinal.ViewModel
{
    public class todoAddVm
    {

        [Required]
        public String Libelle { get; set; }
        
        public String Description { get; set; }
        public State State { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Datetime { get; set; }
    }
}
