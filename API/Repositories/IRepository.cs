using API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IRepository
    {
        Task<List<Employees>> GetEmployeesAsync();
        Task<Employees> GetEmployeeAsync(Guid EmployeeId);
        Task<Employees> AddEmployeeAsync(Employees employee);
        Task<Employees> UpdateEmployeeAsync(Guid EmployeeId, Employees employee);
        Task<Employees> DeleteEmployeeAsync(Guid EmployeeId);
    }
}
