using EmployeeManagementCore.Models;

namespace EmployeeManagementCore.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        public List<Employee> GetAllEmployees()
        {
            return new List<Employee>
            {
                new Employee {Name = "RRN", Email = "rrn@gmail.com", Department = "HR"},
                new Employee {Name = "ABC", Email = "abc@gmail.com", Department = "Tech"},
            };
        }
    }
}
