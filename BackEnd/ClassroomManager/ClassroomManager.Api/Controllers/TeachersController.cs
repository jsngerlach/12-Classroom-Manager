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
    public class TeachersController : ApiController
    {
        private ClassromDataConext db = new ClassromDataConext();

        // GET: api/Teachers
        public IHttpActionResult GetTeachers()
        {
            //SELECT Name Email Telephone FROM Teachers
            var resultSet = db.Teachers.Select(t => new
            {
                t.TeacherId,
                t.Name,
                t.EmailAddress,
                t.StartDate,
                t.EndDate,
                t.Telephone,
              Classes = t.Classes.Count
            });
            return Ok(resultSet);
        }

        // GET: api/Teachers/5
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult GetTeacher(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                teacher.TeacherId,
                teacher.Name,
                teacher.EmailAddress,
                teacher.Telephone,
                teacher.StartDate,
                teacher.EndDate,
                Classes = teacher.Classes.Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate
                })
            });
        }

        // PUT: api/Teachers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeacher(int id, Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacher.TeacherId)
            {
                return BadRequest();
            }
            var dbTeacher = db.Teachers.Find(id);

            dbTeacher.Name = teacher.Name;
            dbTeacher.EmailAddress = teacher.EmailAddress;
            dbTeacher.Telephone = teacher.Telephone;

            db.Entry(dbTeacher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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

        // POST: api/Teachers
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult PostTeacher(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teachers.Add(teacher);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teacher.TeacherId }, teacher);
        }

        // DELETE: api/Teachers/5
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult DeleteTeacher(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            db.Teachers.Remove(teacher);
            db.SaveChanges();

            return Ok(teacher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeacherExists(int id)
        {
            return db.Teachers.Count(e => e.TeacherId == id) > 0;
        }
    }
}