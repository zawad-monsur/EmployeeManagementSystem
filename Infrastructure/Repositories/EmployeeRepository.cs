using Domain;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Employees
                .AsNoTracking() // Improves read performance since tracking is not needed
                .Where(e => e.Status)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> SearchAsync(string name)
        {
            return await _context.Employees
                .AsNoTracking()
                .Where(e => e.Status && e.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.EmployeeID == id && e.Status);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.Status = false; // Soft delete
                _context.Entry(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DepartmentAverage>> GetDepartmentAverageScoresAsync()
        {
            List< DepartmentAverage> DepartmentAverages = new List< DepartmentAverage >();
            return await _context.DepartmentAverages
                .FromSqlRaw("EXEC GetDepartmentAverageScores")
                .ToListAsync();
        }
    }
}
