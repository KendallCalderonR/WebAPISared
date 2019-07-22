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
using WebAPI_Sared.Models.API;

namespace WebAPI_Sared.Controllers
{
    public class crud_UsuarioRead_ResultController : ApiController
    {
        private ARE_EskolorEntities db = new ARE_EskolorEntities();

        // GET: api/crud_UsuarioRead_Result
        public IQueryable<crud_UsuarioRead_Result> Getcrud_UsuarioRead_Result()
        {
            return db.crud_UsuarioRead_Result;
        }

        // GET: api/crud_UsuarioRead_Result/5
        [ResponseType(typeof(crud_UsuarioRead_Result))]
        public IHttpActionResult Getcrud_UsuarioRead_Result(int id)
        {
            crud_UsuarioRead_Result crud_UsuarioRead_Result = db.crud_UsuarioRead_Result.Find(id);
            if (crud_UsuarioRead_Result == null)
            {
                return NotFound();
            }

            return Ok(crud_UsuarioRead_Result);
        }

        // PUT: api/crud_UsuarioRead_Result/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcrud_UsuarioRead_Result(int id, crud_UsuarioRead_Result crud_UsuarioRead_Result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != crud_UsuarioRead_Result.ID)
            {
                return BadRequest();
            }

            db.Entry(crud_UsuarioRead_Result).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!crud_UsuarioRead_ResultExists(id))
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

        // POST: api/crud_UsuarioRead_Result
        [ResponseType(typeof(crud_UsuarioRead_Result))]
        public IHttpActionResult Postcrud_UsuarioRead_Result(crud_UsuarioRead_Result crud_UsuarioRead_Result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.crud_UsuarioRead_Result.Add(crud_UsuarioRead_Result);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = crud_UsuarioRead_Result.ID }, crud_UsuarioRead_Result);
        }

        // DELETE: api/crud_UsuarioRead_Result/5
        [ResponseType(typeof(crud_UsuarioRead_Result))]
        public IHttpActionResult Deletecrud_UsuarioRead_Result(int id)
        {
            crud_UsuarioRead_Result crud_UsuarioRead_Result = db.crud_UsuarioRead_Result.Find(id);
            if (crud_UsuarioRead_Result == null)
            {
                return NotFound();
            }

            db.crud_UsuarioRead_Result.Remove(crud_UsuarioRead_Result);
            db.SaveChanges();

            return Ok(crud_UsuarioRead_Result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool crud_UsuarioRead_ResultExists(int id)
        {
            return db.crud_UsuarioRead_Result.Count(e => e.ID == id) > 0;
        }
    }
}