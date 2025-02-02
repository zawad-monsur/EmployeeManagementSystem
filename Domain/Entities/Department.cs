using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Domain.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int? ManagerID { get; set; }
        public decimal Budget { get; set; }

        // Navigation property: One department has many employees.
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
