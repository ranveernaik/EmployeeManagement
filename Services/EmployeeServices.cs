//--------------------------------------------------Day04-----------------------------------------

using EmployeeManagementCore.Datab;
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
    }
}
