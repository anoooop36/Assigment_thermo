using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiCurd.Controllers
{
    public class EmpController : ApiController
    {

        public IHttpActionResult GetAllStudents()
        {
            List<Employee> students;
            using (var ctx = new EmployeeTableEntities())
            {
                students = ctx.Employees.ToList();
            }

            if (students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }



        public IHttpActionResult PostNewStudent(Employee student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new EmployeeTableEntities())
            {
                ctx.Employees.Add(new Employee()
                {
                    Id = student.Id,
                    Name = student.Name,

                });

                ctx.SaveChanges();
            }

            return Ok();
        }

    }
}
