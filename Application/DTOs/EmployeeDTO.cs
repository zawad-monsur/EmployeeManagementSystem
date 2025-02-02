using System;

namespace Application.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public DateTime JoinDate { get; set; }
        public int DepartmentID { get; set; }
        public bool Status { get; set; }
    }
}
