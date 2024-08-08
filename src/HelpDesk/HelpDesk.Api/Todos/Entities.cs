namespace HelpDesk.Api.Todos;

public class TodoItemEntity
{
    public Guid Id { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; } // Huh?

    public string Description { get; set; } = string.Empty;
}