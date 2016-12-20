using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ClassroomManager.Api.Infrastructure;
using ClassroomManager.Api.Models;

namespace ClassroomManager.Api.Controllers
{
    public class StudentsController : ApiController
    {
        private ClassromDataConext db = new ClassromDataConext();

        // GET: api/Students
        public IHttpActionResult GetStudents()
        {
            var resultSet = db.Students.Select(s => new
            {
                s.StudentId,
                s.Name,
                s.EmailAddress,
                s.Telephone,
                Classes = s.Enrollments.Count
            });
            return Ok(resultSet);
        }

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                student.StudentId,
                student.Name,
                student.EmailAddress,
                student.Telephone,
                Classes = student.Enrollments.Select(e => new
                {
                    e.Class.ClassId,
                    e.Class.TeacherId,
                    e.Class.Name,
                    e.Class.StartDate,
                    e.Class.EndDate
                })
            });
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentId)
            {
                return BadRequest();
            }
            var dbStudent = db.Students.Find(id);

            dbStudent.Name = student.Name;
            dbStudent.EmailAddress = student.EmailAddress;
            dbStudent.Telephone = student.Telephone;

            db.Entry(dbStudent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student.StudentId }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.StudentId == id) > 0;
        }
    }
}