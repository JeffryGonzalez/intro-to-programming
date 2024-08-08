

namespace HelpDesk.Api.Todos;

public class NotificationHttpClient(HttpClient client) : INotifyTodoListStuff
{
    // One of these classes per remote API (Origin)


    public async Task CheckForNoticationOnAsync(TodoItemEntity entity)
    {
        var request = new NotificationRequest(entity.CreatedBy, entity.Description);
        var response = await client.PostAsJsonAsync("/notifications", request);
        response.EnsureSuccessStatusCode(); // TODO I'll talk about this in a bit.
        // e.g. "Isn't this what exceptions are made for"
    }
}


public record NotificationRequest(string UserSub, string Description);