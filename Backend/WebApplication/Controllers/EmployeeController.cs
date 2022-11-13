using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Commands;
using WebApplication.Dto;
using WebApplication.Services.Interface;

namespace WebApplication.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("Api/Employee")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees([FromQuery] GetEmployeeWithParametrs command)
        {         
            return Ok(await _employeeService.GetEmployees(command));
        }
        [HttpGet("PerformanceManager")]
        public async Task<ActionResult<List<string>>> GetPerformanceManager()
        {
            return Ok(await _employeeService.GetPerformanceManagers());
        }

    }
}
