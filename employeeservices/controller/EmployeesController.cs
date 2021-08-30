using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using employeeservices.Data;
using employeeservices.models;
namespace EmployeeServiceApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        employeeservicesContext _context;
        public EmployeesController(employeeservicesContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateEmployee(Employee emp)
        {
            _context.Employee.Add(emp);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public List<Employee> GetEmployee()
        {
            var emp = _context.Employee.ToList();
            return emp;
        }
        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
         return NoContent();
        }
        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool EmployeeExists(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public string Getusername(string Email)
        {
            var name = Email.Split('@')[0];
            return name;
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee emp)
        {
            var result = _context.Employee.FirstOrDefault(e => e.Id == emp.Id);
            if (result != null)
            {
                result.Age = emp.Age;
                result.Name = emp.Name;
                result.Country = emp.Country;
                result.Designation = emp.Designation;
                result.ContactNumber = emp.ContactNumber;
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}