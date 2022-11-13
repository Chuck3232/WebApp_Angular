using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Employee : Entity
    {
        public string EmployeeName { get; set; }
        public DateTime HireDate { get; set; }
        public string PerformanceManager { get; set; }

        public Employee(string employeeName, DateTime hireDate, string performanceManager)
        {
            SetEmployeeName(employeeName);
            SetHireDate(hireDate);
            SetPerformanceManager(performanceManager);
        }
        public void SetEmployeeName(string employeeName)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
            {
                throw new Exception("EmployeeName name cannot be empty.");
            }
            EmployeeName = employeeName;
        }
        public void SetHireDate(DateTime hireDate)
        {
            if (hireDate == default(DateTime))
            {
                throw new Exception("HireDate cannot have default value.");
            }
            HireDate = hireDate;
        }
        public void SetPerformanceManager(string performanceManager)
        {
            if (string.IsNullOrWhiteSpace(performanceManager))
            {
                throw new Exception("PerformanceManager name cannot be empty.");
            }
            PerformanceManager = performanceManager;
        }

    }
}
