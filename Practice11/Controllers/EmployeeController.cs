using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practice11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private List<Employee> employees;

        public EmployeeController()
        {
            employees = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Simon", Surname = "Brian", Salary = 200000, Age = 18 },
                new Employee() { Id = 4, Name = "Simon", Surname = "Johnson", Salary = 250000, Age = 20 },
                new Employee() { Id = 2, Name = "Jonathan", Surname = "Joestar", Salary = 200000, Age = 40 },
                new Employee() { Id = 3, Name = "Joseph", Surname = "Joestar", Salary = 300000, Age = 25 },
                new Employee() { Id = 5, Name = "Alan", Surname = "Walker", Salary = 320000, Age = 25 },
                new Employee() { Id = 7, Name = "Takeshi", Surname = "Japanov", Salary = 100000, Age = 17 },
                new Employee() { Id = 6, Name = "Artem", Surname = "Ivanov", Salary = 90000, Age = 16 },
            };
        }


        public delegate bool Adult(int age);

        [HttpGet("age")]
        public IEnumerable<Employee> adults()
        {
            Adult isAdult = age => age >= 18;
            var list = employees.Where(e => isAdult(e.Age)).OrderBy(e => e.Age);
            return list;
        }


        [HttpGet]
        public List<Employee> getAll()
        {
            return employees.OrderBy(e => e.Id).ToList();
        }


        [HttpGet("name/{value}")]
        public List<Employee> GetEmployeesByName(string value)
        {
            var list = employees.Where(x => x.Name.ToLower() == value.ToLower()).ToList();
            return list;
        }


        [HttpGet("surname/{value}")]
        public List<Employee> getEmployeesBySurname(string value)
        {
            var list = from e in employees
                       where e.Surname.ToLower() == value.ToLower()
                       select e;
            return list.ToList();
        }


        [HttpGet("salary/{salary}")]
        public IEnumerable<Employee> SalaryMoreThan(int salary)
        {
            Func<Employee, bool> isGreater = e => e.Salary > salary;
            var list = employees.Where(isGreater).OrderBy(e => e.Salary);
            return list;
        }
    }
}
