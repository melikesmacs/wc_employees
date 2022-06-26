using Employees;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

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
    
app.MapGet("/employees/{id}", (int id) =>
{
    var result = EmployeeData.GetEmployee(id);
    if (result == null) return Results.NotFound($"An employee with id '{id}' was not found in the system.");
    return Results.Ok(result);
});

app.MapPost("/employees", (Employee newEmployee) =>
{
    var result = EmployeeData.CreateEmployee(newEmployee);

    if (result == null)
    {
        return Results.BadRequest($"An employee with id '{newEmployee.Id}' already exists. The new employee was not added.");
    }
    else
    {
        return Results.Ok(result);
    }
   

    //var found = EmployeeData.EmployeeExists(newEmployee.Id);
    //if (found is true)
    //{
    //    var id = newEmployee.Id;
    //    return Results.BadRequest($"An employee with id '{id}' already exists. The new employee was not added.");
    //}
    //else
    //{
    //    var result = EmployeeData.CreateEmployee(newEmployee);
    //    return Results.Ok(result);
    //}
});

app.Run();