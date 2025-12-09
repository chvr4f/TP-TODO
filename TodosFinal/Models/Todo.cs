using System.ComponentModel.DataAnnotations;
using TodosFinal.Enums;

namespace TodosFinal.Models
{
    public class Todo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Libelle { get; set; }
        public String Description { get; set; }
        public State State { get; set; }
        public DateTime Datetime { get; set; }
    }
}
