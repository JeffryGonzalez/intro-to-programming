﻿using Marten;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Todos;

public class TodoListController(
    IDocumentSession session,
    INotifyTodoListStuff _todoListItemNotifications,
    ILogger<TodoListController> logger
    ) : ControllerBase
{

    [HttpGet("/api/todos")]
    public async Task<ActionResult<CollectionResponse<TodoItemResponseModel>>> GetAllTodos()
    {
        // TODO talk about this.
        logger.LogInformation("Getting some todos, yo");
        var items = await session.Query<TodoItemEntity>()
            .Select(t => new TodoItemResponseModel()
            {
                Id = t.Id,
                Completed = !t.CompletedAt.HasValue,
                Description = t.Description

            })
            .ToListAsync();

        var response = new CollectionResponse<TodoItemResponseModel>() { Items = items };
        return Ok(response);
    }

    [HttpPost("/api/todos")]
    public async Task<ActionResult<TodoItemResponseModel>> AddItem([FromBody] TodoItemRequestModel request)
    {
        // todo - validation

        var entity = new TodoItemEntity
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            CreatedAt = DateTimeOffset.Now,
            CreatedBy = "Bob",

        };
        session.Store(entity);
        await session.SaveChangesAsync();

        var response = new TodoItemResponseModel
        {
            Id = entity.Id,
            Completed = entity.CompletedAt != null,
            Description = entity.Description,
        };

        await _todoListItemNotifications.CheckForNoticationOnAsync(entity);
        return Ok(response);
    }
}
