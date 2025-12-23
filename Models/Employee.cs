//----------------------------Day02---------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCore.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Your Name is Required.")]

        public string Name { get; set; }

        [Required(ErrorMessage ="Your Email is Required.") ]      
        public string Email { get; set; }

        [Required(ErrorMessage = "Your Department is Required.")]

        public string Department { get; set; }

    }
}
