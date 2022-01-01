using API.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployeeAsync(Employee request)
        {
            var employee = await _context.Employee.AddAsync(request);
            await _context.SaveChangesAsync();
            return employee.Entity;
        }

        public async Task<Employee> DeleteEmployeeAsync(Guid EmployeeId)
        {
            var employee = await _context.Employee.FindAsync(EmployeeId);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            return null;
        }

        public async Task<Employee> GetEmployeeAsync(Guid EmployeeId)
        {
            var employee = await _context.Employee.FindAsync(EmployeeId);
            return employee;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(Guid EmployeeId, Employee employee)
        {
            var existingemployee = await GetEmployeeAsync(EmployeeId);
            if (existingemployee != null)
            {
                existingemployee.FirstName = employee.FirstName;
                existingemployee.LastName = employee.LastName;
           //     existingemployee.Title = employee.Title;
                existingemployee.Email = employee.Email;

                await _context.SaveChangesAsync();
                return existingemployee;
            }
            return null;
        }
    }
}
