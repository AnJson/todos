using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Contracts.Todo
{
    public record CreateTodoRequest(
        string Title,
        string Description,
        bool Done
        );
}
