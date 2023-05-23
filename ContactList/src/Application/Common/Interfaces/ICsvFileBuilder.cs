using ContactList.Application.TodoLists.Queries.ExportTodos;

namespace ContactList.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
