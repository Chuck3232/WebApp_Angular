using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Commands
{
    public class GetEmployeeWithParametrs
    {      
        public string employeeName { get; set; }
        public string dateAfter { get; set; }
        public string dateBefore { get; set; }
        public string managerName { get; set; }
    }
}
