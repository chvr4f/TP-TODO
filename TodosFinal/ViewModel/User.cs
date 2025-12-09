using System.ComponentModel.DataAnnotations;

namespace TodosFinal.ViewModel
{
    public class User
    {
        [Required]
        public String Login { get; set; }
        [DataType(DataType.Password)]
        [Required]

        public String Password { get; set; }

    }
}
