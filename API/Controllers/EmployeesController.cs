using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IRepository _repository;

        public EmployeesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _repository.GetEmployeesAsync();
            return Ok(employees);
        }
    }
}
