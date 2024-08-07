using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api;

public class DemoController : ControllerBase
{
    private HttpClient _httpClient;

    public DemoController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet("/api/status")]
    public async Task<ActionResult> GetStatus()
    {
        await _httpClient.GetAsync("https://tacos.are.delicious.com");

        return Ok("Looks Good");
    }
}
