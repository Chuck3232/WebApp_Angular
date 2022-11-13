using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Dto
{
    public class EmployeeDto
    {
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string HireDate { get; set; }
        [Required]
        public string PerformanceManager { get; set; }
    }
}
