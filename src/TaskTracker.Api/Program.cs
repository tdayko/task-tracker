using Microsoft.OpenApi.Models;

using TaskTracker.Api.Controllers;
using TaskTracker.Application;
using TaskTracker.Application.Errors;
using TaskTracker.Application.Repositories;
using TaskTracker.Infra;
using TaskTracker.Infra.Repository;

#region Builder Services

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCoreDbContext(builder.Configuration);
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddApplication();
builder.Services.AddSwaggerGen(x =>
    x.SwaggerDoc("v1",
        new OpenApiInfo { Title = "Task tracker API", Description = "Keep track of your tasks as an ", Version = "v1" }
    ));

WebApplication app = builder.Build();

#endregion

#region App Configuration

app.UseHttpsRedirection(); 
app.UseExceptionHandler("/error");
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Task tracker API"));
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();
app.Run();

#endregion