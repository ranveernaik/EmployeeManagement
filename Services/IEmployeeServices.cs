//------------------------------------------------------Day04---------------------------------

using EmployeeManagementCore.Models;
namespace EmployeeManagementCore.Services
{
    public interface IEmployeeServices
    {
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        Employee GetEmployee(int id);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);

    }
}
