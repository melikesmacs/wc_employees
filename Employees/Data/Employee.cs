

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


    public static Array GetEmployees()
    {
        var items =
            from e in _employees
            select new { e.LastName, e.FirstName, e.Department };

        return items.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToArray();
    }

    public static Employee? GetEmployee(int id)
    {
        return _employees.SingleOrDefault(employee => employee.Id == id);
    }

    public static Employee? CreateEmployee(Employee newEmployee)
    {
        var found = EmployeeExists(newEmployee.Id);
        if (found is true)
        {
            return null;
        }
        else
        {
            _employees.Add(newEmployee);
            return newEmployee;
        }
    }

    // Note: This validation should take place in the data store and the resulting
    //       success or failure propagated back to the caller accordingly.
    public static bool EmployeeExists(int id)
    {
        var employeeExists = _employees.Where(e => e.Id == id).SingleOrDefault();

        if (employeeExists is null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}