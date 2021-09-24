using abc.Validations;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace abc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employeeList = new List<Employee>()
        {
            new Employee(){Id = 1, Name = "İlker", Profession = "Engineer",Age = 23},
            new Employee(){Id = 2, Name = "Özge", Profession = "Doctor",Age = 32},
            new Employee(){Id = 3, Name = "Mehmet", Profession = "Grocer",Age = 19},
            new Employee(){Id = 4, Name = "Feyza", Profession = "Teacher",Age = 45},
            new Employee(){Id = 5, Name = "Ali", Profession = "Engineer",Age = 32},
            new Employee(){Id = 6, Name = "Fatma", Profession = "Teacher",Age = 24},
            new Employee(){Id = 7, Name = "Enis", Profession = "Assistant",Age = 40},
            new Employee(){Id = 8, Name = "Ahmet", Profession = "Cleaner",Age = 37},
            new Employee(){Id = 9, Name = "Emine", Profession = "Manager",Age = 31},
            new Employee(){Id = 10, Name = "Buse", Profession = "Engineer",Age = 27},
            new Employee(){Id = 11, Name = "Furkan", Profession = "Consultant",Age = 50},
            new Employee(){Id = 12, Name = "Ayşe", Profession = "Doctor",Age = 47},
        };
        EmployeeValidator employeeValidator = new EmployeeValidator();

        // GET: api/employee
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employeeList);
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            return Ok(employeeList.FirstOrDefault(x => x.Id == id));
        }


        // When enters age value, returns greater age values than entered age values
        [HttpGet("list")]
        public IActionResult GetEmployeesFromQueryList([FromQuery] string name = "", 
                                                    [FromQuery] string profession = "",
                                                    [FromQuery] int age = 18)
        {
            return Ok(employeeList.Where(x => x.Name.ToLower().Contains(name))
                .Where(x => x.Profession.ToLower().Contains(profession))
                .Where(x => x.Age >= age));
        }

        [HttpGet("sort")]
        public IActionResult GetEmployeesFromQuerySort([FromQuery] bool id = false,
                                                    [FromQuery] bool name = false,
                                                    [FromQuery] bool profession = false,       
                                                    [FromQuery] bool age = false)
        {
            if (id)
            {
                return Ok(employeeList.OrderBy(x => x.Id));
            } 
            else if (name)
            {
                return Ok(employeeList.OrderBy(x => x.Name));
            }
            else if (profession)
            {
                return Ok(employeeList.OrderBy(x => x.Profession));
            }
            else if (age)
            {
                return Ok(employeeList.OrderBy(x => x.Age));
            } else
            {
                return BadRequest("Plese select sorting element for example '../sort?name=true'");
            }

        }

        // POST api/employee
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            ValidationResult result = employeeValidator.Validate(employee);
            List<string> errors = new List<string>();
            if (result.IsValid)
            {
                employeeList.Add(employee);
                return Ok("Successfully added!");
            } else
            {
                ((List<FluentValidation.Results.ValidationFailure>)result.Errors).ForEach(e => errors.Add(e.ErrorMessage));
                return BadRequest(String.Join("\n", errors.ToArray()));
            }
        }

        // PUT api/employee
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            ValidationResult result = employeeValidator.Validate(employee);
            List<string> errors = new List<string>();
            if (result.IsValid)
            {
                var updatingEmployee = employeeList.FirstOrDefault(x => x.Id == employee.Id);
                employeeList.Remove(updatingEmployee);
                employeeList.Add(employee);
                return Created($"api/employee/{employee.Id}", employee);
            } else
            {
                ((List<FluentValidation.Results.ValidationFailure>)result.Errors).ForEach(e => errors.Add(e.ErrorMessage));
                return BadRequest(String.Join("\n", errors.ToArray()));
            }
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (employeeList.Exists(x => x.Id == id))
            {
                employeeList.Remove(employeeList.FirstOrDefault(x => x.Id == id));
                return Ok("Successfully deleted!");
            } else
            {
                return BadRequest("Invalid id value");
            }
            
        }
    }
}
