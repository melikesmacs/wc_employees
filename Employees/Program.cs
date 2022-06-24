using Employees;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

WebApplication app = AppSetup();

app.Run();

static WebApplication AppSetup()
{
    var builder = WebApplication.CreateBuilder();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Wake County Employee API",
            Description = "ASP.NET 6.x Web API for Wake County employee management."
        });
    });

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
        });
    }

    // Add endpoints
    app.MapGet("/employees", () => EmployeeData.GetEmployees());
    app.MapGet("/employees/{id}", (int id) => EmployeeData.GetEmployee(id));
    app.MapPost("/employees", (Employee newEmployee) => EmployeeData.CreateEmployee(newEmployee));
    return app;
}