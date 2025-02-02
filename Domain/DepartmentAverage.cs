using Microsoft.EntityFrameworkCore;

namespace Domain
{
    [Keyless]
    public class DepartmentAverage
    {
        public string DepartmentName { get; set; }
        public double AverageScore { get; set; }
    }
}
