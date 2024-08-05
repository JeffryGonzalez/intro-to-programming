using Marten;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Api.Software;


public class SoftwareController : ControllerBase
{
    private IDocumentSession _documentSession;

    public SoftwareController(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }


    // GET /api/software

    [HttpGet("/api/software")]
    public async Task<ActionResult> GetTheSoftwareCatalog()
    {
        var fakeData = await _documentSession.Query<SoftwareItem>().ToListAsync(); // database
        return Ok(fakeData); // take that data and turn into JSON - and give it a 200OK
    }

    [HttpPost("/api/software")]
    public async Task<ActionResult> AddSoftwareToCatalog([FromBody] CreateSoftwareItemRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var thingToSaveInTheDatabase = new SoftwareItem(Guid.NewGuid(), request.Title);
        _documentSession.Store(thingToSaveInTheDatabase);
        await _documentSession.SaveChangesAsync();
        return Ok(thingToSaveInTheDatabase);
    }


}

public record SoftwareItem
{

    public SoftwareItem(Guid id, string title)
    {
        Id = id;
        Title = title;
    }
    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
}

public record SoftwareItem2(Guid Id, string Title);
public record CreateSoftwareItemRequest
{
    [Required, MinLength(3), MaxLength(100)]
    public string Title { get; set; } = string.Empty;
}
