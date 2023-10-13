using System.ComponentModel.DataAnnotations;

namespace AddEditDemo.Areas.EMP_Department.Models
{
    public class EMP_DepartmentModel
    {
        public int? DepID { get; set; }

        [Required]
        public string Department { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
    public class DepartmentDropDown
    {
        public int DepID { get; set; }
        public string Department { get; set; }

    }
}
