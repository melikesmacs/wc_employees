namespace Employees;

public record Employee
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Department { get; set; }
    public DateTime HireDate { get; set; }
}

public class EmployeeData
{
    private static List<Employee> _employees = new()
    {
        new Employee { Id = 1, FirstName = "Alberta", LastName = "Jackson", Department = "Finance", HireDate = new DateTime(2007, 6, 5) },
        new Employee { Id = 2, FirstName = "Alicia", LastName = "Bennett", Department = "Human Resources", HireDate = new DateTime(2001, 4, 15) },
        new Employee { Id = 3, FirstName = "Donna", LastName = "Avent", Department = "Revenue", HireDate = new DateTime(2009, 4, 20) },
        new Employee { Id = 4, FirstName = "Duane", LastName = "Holder", Department = "Human Services", HireDate = new DateTime(2020, 8, 15) }
    };


    public static List<Employee> GetEmployees()
    {
        return _employees;
    }

    public static Employee? GetEmployee(int id)
    {
        return _employees.SingleOrDefault(employee => employee.Id == id);
    }

    public static Employee CreateEmployee(Employee newEmployee)
    {
        _employees.Add(newEmployee);
        return newEmployee;
    }

    public static bool EmployeeExists(int id)
    {
        var employeeExists = _employees.Where(e => e.Id == id).FirstOrDefault();
        return employeeExists == null;
    }
}   