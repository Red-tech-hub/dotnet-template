using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace MyWeatherApi;

/// <summary>
/// Transforms the OpenAPI document to add title, version, and description
/// </summary>
public sealed class DocumentInfoTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        document.Info = new OpenApiInfo
        {
            Title = "DotNet Template API",
            Version = "v1",
            Description = "A standard template API built with ASP.NET Core"
        };

        return Task.CompletedTask;
    }
}
