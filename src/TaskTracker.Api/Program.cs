using Microsoft.OpenApi.Models;

using TaskTracker.Core;

#region Builder Services

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCoreDbContext(builder.Configuration);
builder.Services.AddSwaggerGen(x =>
    x.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Inter task tracker API", Description = "Keep track of your tasks as an ", Version = "v1"
        }
    ));

WebApplication app = builder.Build();

#endregion

#region App Configuration

app.UseSwagger();
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", " task tracker API"));
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.UseHttpsRedirection();
app.Run();

#endregion