
namespace HelpDesk.Api.Todos;

public interface INotifyTodoListStuff
{
    Task CheckForNoticationOnAsync(TodoItemEntity entity);
}
