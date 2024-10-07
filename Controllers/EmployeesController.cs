using alte_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(dbContext.Employees.ToList());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeId(Guid id)
        {
           var employee = dbContext.Employees.Find(id);
           if(employee is null)
           {
            return NotFound();
             
           }
           return Ok(employee);

           
        }

        [HttpPost]
        public IActionResult AddEmployees(AddEmployeeDto employeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Phone = employeeDto.Phone,
                Salary = employeeDto.Salary
            };

            dbContext.Add(employeeEntity);
            dbContext.SaveChanges();
            return Ok(employeeEntity);

        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, AddEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee is null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            dbContext.SaveChanges();
            return Ok(employee);

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee is null)
            {
                return NotFound();
            }
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return Ok();

        }


    }
} 
