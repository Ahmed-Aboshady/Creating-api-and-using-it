using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace api_lab2.Controllers
{
    public class testController : ApiController
    {
        iti db = new iti();
          public IHttpActionResult getall()
         {
             return Ok(db.Courses.ToList());
         }
        [ResponseType(typeof(Course))]
        public IHttpActionResult Getcourse(int id)
        {
            Course crs = db.Courses.Find(id);
            if (crs == null)
            {
                return NotFound();
            }

            return Ok(crs);
        }

        [ResponseType(typeof(Course))]
        public IHttpActionResult PostStudent(Course crs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(crs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = crs.Crs_Id }, crs);
        }

        
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Course crs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != crs.Crs_Id)
            {
                return BadRequest();
            }

            db.Entry(crs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExist(id))
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

        private bool CourseExist(int id)
        {
            return db.Courses.Count(e => e.Crs_Id == id) > 0;
        }
        
        [ResponseType(typeof(Course))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Course crs = db.Courses.Find(id);
            if (crs == null)
            {
                return NotFound();
            }

            db.Courses.Remove(crs);
            db.SaveChanges();

            return Ok(crs);
        }

    }
}
