using Marten;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Software;

public class SoftwareLookupController(IDocumentSession _documentSession) : ControllerBase
{
    // GET /api/software/tacos
    [HttpGet("/api/software/{id:guid}")]
    public async Task<ActionResult> GetSoftwareById(string id)
    {
        var response = await _documentSession.Query<SoftwareItem>().Where(item => item.Id == Guid.Parse(id)).SingleOrDefaultAsync();
        if (response is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response);
        }
    }
}

