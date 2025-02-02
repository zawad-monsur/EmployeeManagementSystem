using Domain;
using EmployeeManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync(int page, int pageSize);
        Task<IEnumerable<Employee>> SearchAsync(string name);
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
        Task<IEnumerable<DepartmentAverage>> GetDepartmentAverageScoresAsync();
    }
}
