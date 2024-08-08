using System;
using Microsoft.AspNetCore.Mvc;

namespace NotificationApi;

public static class NotificationApi
{
    public static IEndpointRouteBuilder UseNotificationApi(this IEndpointRouteBuilder routes)
    {

        routes.MapPost("/notifications2", (NotificationRequest request, [FromServices] ILogger logger) =>
        {

            logger.LogInformation("A request was made for {0}", request.Description); // DUH!

            return TypedResults.NoContent();
        });

        return routes;
    }
}
