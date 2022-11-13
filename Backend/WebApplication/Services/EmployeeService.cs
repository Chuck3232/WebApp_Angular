using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Commands;
using WebApplication.DbContext;
using WebApplication.Dto;
using WebApplication.Services.Interface;

namespace WebApplication.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees(GetEmployeeWithParametrs command)
        {

            var employees = await _dbContext.Employees.ToListAsync();

            if (!string.IsNullOrWhiteSpace(command.employeeName))          
               employees = employees.Where(e => e.EmployeeName.ToLower().Contains(command.employeeName.ToLower())).ToList();

            if (!string.IsNullOrWhiteSpace(command.dateAfter) && string.IsNullOrWhiteSpace(command.dateBefore))
                employees = employees.Where(e => e.HireDate >= DateTime.Parse(command.dateAfter)).ToList();
            else if (string.IsNullOrWhiteSpace(command.dateAfter) && !string.IsNullOrWhiteSpace(command.dateBefore))
                employees = employees.Where(e => e.HireDate <= DateTime.Parse(command.dateBefore)).ToList();
            else if (!string.IsNullOrWhiteSpace(command.dateAfter) && !string.IsNullOrWhiteSpace(command.dateBefore))
                employees = employees.Where(e => e.HireDate >= DateTime.Parse(command.dateAfter) && e.HireDate <= DateTime.Parse(command.dateBefore)).ToList();

            if (!string.IsNullOrWhiteSpace(command.managerName))
                employees = employees.Where(e => e.PerformanceManager.ToLower().Contains(command.managerName.ToLower())).ToList();

            var employeesDto = employees.Select(e => new EmployeeDto
            {
                EmployeeName = e.EmployeeName,
                HireDate = e.HireDate.ToString("dd/MM/yyyy"),
                PerformanceManager = e.PerformanceManager,
            });   
            
            return employeesDto.ToList();       
        }

        public async Task<List<string>> GetPerformanceManagers()
        {
            var performanceMangers = await _dbContext.Employees.Select(p => p.PerformanceManager)
                                 .Distinct().ToListAsync();

            return performanceMangers;
        }
    }
}
