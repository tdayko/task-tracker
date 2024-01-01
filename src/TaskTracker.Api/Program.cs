using Microsoft.OpenApi.Models;

using TaskTracker.Application;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Repository;
using TaskTracker.Infra;

#region Builder Services

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

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

app.UseSwagger();
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", " task tracker API"));
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

#endregion