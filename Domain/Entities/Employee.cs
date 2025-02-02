using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public DateTime JoinDate { get; set; }
        public int DepartmentID { get; set; }
        public bool Status { get; set; } 

        // Navigation property
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }
    }
}
