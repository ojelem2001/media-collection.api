using FastEndpoints;
using FluentValidation.Results;

namespace MediaCollection.API.Validation;

/// <inheritdoc/>
public class UserGuidPreProcessor : IPreProcessor<object>
{
    /// <inheritdoc/>
    public async Task PreProcessAsync(IPreProcessorContext<object> context, CancellationToken ct)
    {
        var routeGuid = context.HttpContext.Request.RouteValues["userGuid"]?.ToString();

        if (string.IsNullOrEmpty(routeGuid))
        {
            context.ValidationFailures.Add(new ValidationFailure
            {
                PropertyName = "UserGuid",
                ErrorMessage = "User GUID is required in the route"
            });
            await context.HttpContext.Response.SendErrorsAsync(context.ValidationFailures, cancellation: ct);
            return;
        }

        if (!Guid.TryParse(routeGuid, out var parsedRouteGuid))
        {
            context.ValidationFailures.Add(new ValidationFailure
            {
                PropertyName = "UserGuid",
                ErrorMessage = "Invalid User GUID format in route"
            });
            await context.HttpContext.Response.SendErrorsAsync(context.ValidationFailures, cancellation: ct);
            return;
        }

        var userGuidClaim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserGuid")?.Value;

        if (string.IsNullOrEmpty(userGuidClaim))
        {
            context.ValidationFailures.Add(new ValidationFailure
            {
                PropertyName = "UserGuid",
                ErrorMessage = "User GUID claim not found in token"
            });
            await context.HttpContext.Response.SendErrorsAsync(context.ValidationFailures, cancellation: ct);
            return;
        }

        if (!Guid.TryParse(userGuidClaim, out var parsedTokenGuid))
        {
            context.ValidationFailures.Add(new ValidationFailure
            {
                PropertyName = "UserGuid",
                ErrorMessage = "Invalid User GUID format in token"
            });
            await context.HttpContext.Response.SendErrorsAsync(context.ValidationFailures, cancellation: ct);
            return;
        }

        if (parsedRouteGuid != parsedTokenGuid)
        {
            context.ValidationFailures.Add(new ValidationFailure
            {
                PropertyName = "UserGuid",
                ErrorMessage = "User GUID in route does not match token"
            });
            await context.HttpContext.Response.SendErrorsAsync(context.ValidationFailures, cancellation: ct);
            return;
        }
    }
}