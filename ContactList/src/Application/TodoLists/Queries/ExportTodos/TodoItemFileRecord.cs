using ContactList.Application.Common.Mappings;
using ContactList.Domain.Entities;

namespace ContactList.Application.TodoLists.Queries.ExportTodos;
public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
