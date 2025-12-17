using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCore.ViewModels
{
    public class EmployeeViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Department {  get; set; }
    }
}
