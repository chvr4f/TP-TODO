using Microsoft.CodeAnalysis.CSharp.Syntax;
using TodosFinal.Models;
using TodosFinal.ViewModel;

namespace TodosFinal.Mapper
{
    public class TodoMapper
    {
        public static Todo GetTodoFromTodoAddVm(todoAddVm vm)
        {
            return new Todo
            {
                Libelle = vm.Libelle,
                Description = vm.Description,
                Datetime = vm.Datetime,
                State = vm.State,

            };
                

        }
        
    }
}
