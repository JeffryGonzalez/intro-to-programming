namespace HelpDesk.Api.Todos;

public record TodoItemResponseModel
{

    public Guid Id { get; init; }
    public bool Completed { get; init; }
    public string Description { get; init; } = string.Empty;
}

public record TodoItemRequestModel
{
    public string Description { get; init; } = string.Empty;
}

public record CollectionResponse<T>
{
    public IReadOnlyList<T> Items { get; init; } = [];

}