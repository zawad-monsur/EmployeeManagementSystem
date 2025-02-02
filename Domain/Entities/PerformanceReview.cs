using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Domain.Entities
{
    public class PerformanceReview
    {
        [Key] 
        public int ReviewID { get; set; }

        public int EmployeeID { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ReviewScore { get; set; }
        public string ReviewNotes { get; set; }

        // Navigation property to Employee
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
    }
}
