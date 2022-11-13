using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbContext;
using WebApplication.Models;

namespace WebApplication.Seeder
{
    public class EmployeeSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (!_dbContext.Employees.Any())
            {
                var employees = GetEmployees();
                _dbContext.Employees.AddRange(employees);
                _dbContext.SaveChanges();
            }
        }

        private IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>()
            {
                new Employee("Richard Tea",new DateTime(2002,01,10),"Richard Tea"),
                new Employee("Alan Fresco",new DateTime(2004,05,30),"Richard Tea"),
                new Employee("Manuel Internetiquette",new DateTime(2005,05,20),"Richard Tea"),
                new Employee("Gunther Beard",new DateTime(2008,05,12),"Alan Fresco"),
                new Employee("Hilary Ouse",new DateTime(2016,01,01),"Alan Fresco"),                          
                new Employee("Thomas R. Toe",new DateTime(2016,02,14),"Alan Fresco"),
                new Employee("Theodore Handle",new DateTime(2016,03,30),"Alan Fresco"),
                new Employee("Jarvis Pepperspray",new DateTime(2016,04,28),"Manuel Internetiquette"),
                new Employee("Gustav Purpleson",new DateTime(2017,08,09),"Manuel Internetiquette"),
                new Employee("Samuel Serif",new DateTime(2018,07,11),"Manuel Internetiquette"),
                new Employee("Quiche Hollandaise",new DateTime(2019,12,22),"Manuel Internetiquette"),
            };
            return employees;
        }
    }
}

