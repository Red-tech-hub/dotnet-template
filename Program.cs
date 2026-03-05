using MyWeatherApi.Middleware;
using MyWeatherApi.Services;
using MyWeatherApi.Services.Interfaces;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;
using MyWeatherApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IItemService, ItemService>();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add OpenAPI services (ASP.NET Core built-in)
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_1;
    options.AddDocumentTransformer<DocumentInfoTransformer>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
    // Map OpenAPI document endpoint
    app.MapOpenApi();
    
    // Enable Swagger UI for interactive API documentation
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "DotNet Template API v1");
        options.RoutePrefix = "swagger"; // Serve Swagger UI at /swagger
    });
}

app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();