using Osirisgate.Lemonsqueezy.Events;
using Osirisgate.Lemonsqueezy.Events.Payloads;
using Osirisgate.Lemonsqueezy.Exception;
using Osirisgate.Lemonsqueezy.Extensions;

namespace Osirisgate.Lemonsqueezy.Demo.Api.Endpoints;

/// <summary>
/// Extension methods for mapping Lemonsqueezy API endpoints.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class EndpointExtensions
{
    /// <summary>
    /// Maps Lemonsqueezy resource endpoints.
    /// </summary>
    public static WebApplication MapLemonsqueezyEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/v1").WithTags("Lemonsqueezy");

        group.MapGet("/user", GetAuthenticatedUser)
            .WithName("GetAuthenticatedUser")
            .Produces(200)
            .Produces(401);

        group.MapGet("/stores", GetAllStores)
            .WithName("GetAllStores")
            .Produces(200)
            .Produces(401);

        group.MapPost("/webhooks/subscriptions/payment_success", HandleWebhookPayment)
            .WithName("HandleWebhookPayment")
            .Produces(200)
            .Produces(400)
            .Produces(401);

        return app;
    }

    /// <summary>
    /// Retrieves the authenticated user.
    /// </summary>
    private static async Task<IResult> GetAuthenticatedUser(
        ILemonsqueezyClient client,
        CancellationToken cancellationToken)
    {
        try
        {
            var user = await client.UsersResource().RetrieveUserAsync(cancellationToken);
            return Results.Ok(new { success = true, data = user });
        }
        catch (BaseException ex)
        {
            return HandleApiException(ex);
        }
        catch (System.Exception ex)
        {
            return HandleUnexpectedException(ex);
        }
    }

    /// <summary>
    /// Retrieves all stores.
    /// </summary>
    private static async Task<IResult> GetAllStores(
        ILemonsqueezyClient client,
        HttpContext httpContext,
        CancellationToken cancellationToken)
    {
        try
        {
            // Extract and parse nested query parameters as filters using SDK extension method
            var filters = httpContext.Request.ParseNestedQueryParameters();
            
            // or via Query property directly
            // var filters = httpContext.Request.Query.ParseNestedQueryParameters();

            var stores = await client.StoresResource().ListAllStoresAsync(
                filters: filters.Count > 0 ? filters : null,
                cancellationToken: cancellationToken
            );
            return Results.Ok(new { success = true, data = stores });
        }
        catch (BaseException ex)
        {
            return HandleApiException(ex);
        }
        catch (System.Exception ex)
        {
            return HandleUnexpectedException(ex);
        }
    }

    /// <summary>
    /// Handles webhook payment events from Lemonsqueezy.
    /// </summary>
    /// <remarks>
    /// The webhook signature is validated by the WebhookValidationMiddleware from the SDK.
    /// The raw body is available in HttpContext.Items[WebhookValidationMiddleware.WebhookRawBodyKey].
    /// This method uses GetEventTypeFromRawBody for performance optimization, only deserializing the payload if needed.
    /// </remarks>
    private static Task<IResult> HandleWebhookPayment(
        HttpContext httpContext,
        CancellationToken cancellationToken)
    {
        try
        {
            // Get raw body first
            var rawBody = httpContext.GetLemonsqueezyWebhookRawBody();
            
            // Get event type without full deserialization for performance
            var eventType = WebhookPayloadDeserializer.GetEventTypeFromRawBody(rawBody);
            
            // Only deserialize if it's a payment event
            if (eventType.IsEventType(WebhookEvent.SubscriptionPaymentSuccess))
            {
                var payload = WebhookPayloadDeserializer.Deserialize(rawBody);
                
                return Task.FromResult(Results.Ok(new
                {
                    success = true,
                    eventType = eventType.GetValue(),
                    data = (object)payload // Cast to object to preserve derived type properties during serialization
                }));
            }
            
            // Return early for non-payment events
            return Task.FromResult(Results.Ok(new
            {
                success = true,
                eventType = eventType.GetValue(),
                skipped = true,
                message = "Event type is not a payment event"
            }));
        }
        catch (BaseException ex)
        {
            return Task.FromResult(HandleApiException(ex));
        }
        catch (System.Exception ex)
        {
            return Task.FromResult(HandleUnexpectedException(ex));
        }
    }

    /// <summary>
    /// Handles API exceptions and returns appropriate HTTP responses.
    /// </summary>
    private static IResult HandleApiException(BaseException ex)
    {
        var errorResponse = ex.Format();
        var statusCode = ex.GetErrorCode() switch
        {
            401 => StatusCodes.Status401Unauthorized,
            404 => StatusCodes.Status404NotFound,
            429 => StatusCodes.Status429TooManyRequests,
            _ => StatusCodes.Status400BadRequest
        };

        return Results.Json(errorResponse, statusCode: statusCode);
    }

    /// <summary>
    /// Handles unexpected exceptions and returns a generic error response.
    /// </summary>
    private static IResult HandleUnexpectedException(System.Exception ex)
    {
        return Results.BadRequest(new
        {
            success = false,
            error = ex.Message
        });
    }
}
