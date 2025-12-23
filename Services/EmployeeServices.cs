//--------------------------------------------------Day04-----------------------------------------

using EmployeeManagementCore.Data;
using EmployeeManagementCore.Models;

namespace EmployeeManagementCore.Services
{
    public class EmployeeServices : IEmployeeServices
    {

        private readonly AppDbContext appDbContext;

        public EmployeeServices(AppDbContext context)
        {
            appDbContext = context;

        }
        public List<Employee> GetAllEmployees()
        {
            return appDbContext.Employees.ToList();
        }

        public void AddEmployee(Employee employee)
        {
            appDbContext.Employees.Add(employee);
            appDbContext.SaveChanges();
        }

        public Employee GetEmployee(int id)
        {
            return appDbContext.Employees.Find(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            appDbContext.Employees.Update(employee);
            appDbContext.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = appDbContext.Employees.Find(id);
            if(employee != null)
            {
                appDbContext.Employees.Remove(employee);
                appDbContext.SaveChanges();
            }
        }
    }
}
