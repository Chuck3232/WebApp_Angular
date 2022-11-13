using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Commands;
using WebApplication.Dto;

namespace WebApplication.Services.Interface
{
    public interface IEmployeeService : IService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployees(GetEmployeeWithParametrs command);
        Task<List<string>> GetPerformanceManagers();
    }
}
