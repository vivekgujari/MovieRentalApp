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
        public async Task<Employees> AddEmployeeAsync(Employees request)
        {
            var employee = await _context.Employees.AddAsync(request);
            await _context.SaveChangesAsync();
            return employee.Entity;
        }

        public async Task<Employees> DeleteEmployeeAsync(Guid EmployeeId)
        {
            var employee = await _context.Employees.FindAsync(EmployeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            return null;
        }

        public async Task<Employees> GetEmployeeAsync(Guid EmployeeId)
        {
            var employee = await _context.Employees.FindAsync(EmployeeId);
            return employee;
        }

        public async Task<List<Employees>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employees> UpdateEmployeeAsync(Guid EmployeeId, Employees employee)
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
