
using Alba;
using HelpDesk.Api.Software;

namespace HelpDesk.Tests.Software;
public class CanAddSoftware
{
    [Fact]
    public async Task CanAddAPieceOfSoftware()
    {
        // "Happy Path" - POST a new item to the API.
        // Look at the response (200, and we get something back).
        // And then using the ID for that thing, see if we can get it back out again.

        // Given
        var host = await AlbaHost.For<Program>();
        var itemToPost = new CreateSoftwareItemRequest
        {
            Title = "Jetbrains Rider"
        };


        // When
        var postResponse = await host.Scenario(api =>
        {
            api.Post.Json(itemToPost).ToUrl("/api/software");
            api.StatusCodeShouldBeOk();
        });

        var addedSoftwareItem = await postResponse.ReadAsJsonAsync<SoftwareItem>();

        Assert.NotNull(addedSoftwareItem);

        Assert.Equal("Jetbrains Rider", addedSoftwareItem.Title);

        var getResponse = await host.Scenario(api =>
        {
            api.Get.Url($"/api/software/{addedSoftwareItem.Id}");
            api.StatusCodeShouldBeOk();
        });

        var getResponseSoftwareItem = await getResponse.ReadAsJsonAsync<SoftwareItem>();

        Assert.Equal(addedSoftwareItem, getResponseSoftwareItem);

    }
}
