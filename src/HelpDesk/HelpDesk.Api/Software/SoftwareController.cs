using Marten;
using Microsoft.AspNetCore.Mvc;

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
        var thingToSaveInTheDatabase = new SoftwareItem(Guid.NewGuid().ToString(), request.Title);
        _documentSession.Store(thingToSaveInTheDatabase);
        await _documentSession.SaveChangesAsync();
        return Ok(thingToSaveInTheDatabase);
    }


}

public record SoftwareItem(string Id, string Title);

public record CreateSoftwareItemRequest
{
    public string Title { get; set; } = string.Empty;
}
