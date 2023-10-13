using System.ComponentModel.DataAnnotations;
using AddEditDemo.Models;

namespace AddEditDemo.Areas.EMP_Employee.Models
{
    public class EMP_EmployeeModel
    {
        public int? EmployeeID { get; set; }
        public int DepID { get; set; }
        public string Department { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public string? Address { get; set; }
        [Required]
        public string Gender { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Email { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Mobile Number Must Be 10 Digits")]
        public string Mobile { get; set; }
        public int Salary { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public List<HOB_HobbyDropdownModel> Hobbylist { get; set; }
        public HOB_HobbyDropdownModel Hobby { get; set; }
    }

}
