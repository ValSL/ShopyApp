using ShopyApp.Common.Errors;

namespace ShopyApp;

public static class ProblemDetailsHelper
{
    public static IResult ProblemDetails(List<Error> errors)
    {
        return Results.Problem(
            title: errors[0].Message,
            statusCode: errors[0].StatusCode, 
            extensions: new Dictionary<string, object?>() { { "errors", errors.Select(x => x.Name) } });
    }
}