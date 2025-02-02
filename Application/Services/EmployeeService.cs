using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Interfaces;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync(int page, int pageSize)
        {
            var employees = await _employeeRepository.GetAllAsync(page, pageSize);
            return employees.Select(e => _mapper.Map<EmployeeDTO>(e));
        }

        public async Task<IEnumerable<EmployeeDTO>> SearchEmployeesAsync(string name)
        {
            var employees = await _employeeRepository.SearchAsync(name);
            return employees.Select(e => _mapper.Map<EmployeeDTO>(e));
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDTO)
        {
            // Map DTO to domain entity.
            var employee = _mapper.Map<Employee>(employeeDTO);
            // (In a real app, validations would go here.)
            var createdEmployee = await _employeeRepository.AddAsync(employee);
            return _mapper.Map<EmployeeDTO>(createdEmployee);
        }

        public async Task UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DepartmentAverageDTO>> GetDepartmentAverageScoresAsync()
        {
            return (IEnumerable<DepartmentAverageDTO>)await _employeeRepository.GetDepartmentAverageScoresAsync();
        }
    }
}
