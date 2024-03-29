﻿using System;
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
    public class CantonesController : ApiController
    {
        private ARE_EskolorEntities db = new ARE_EskolorEntities();

        // GET: api/Cantones
        public IQueryable<Canton> GetCanton()
        {
            return db.Canton;
        }

        // GET: api/Cantones/5
        [ResponseType(typeof(Canton))]
        public IHttpActionResult GetCanton(int id)
        {
            Canton canton = db.Canton.Find(id);
            if (canton == null)
            {
                return NotFound();
            }

            return Ok(canton);
        }

        // PUT: api/Cantones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCanton(int id, Canton canton)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != canton.ID)
            {
                return BadRequest();
            }

            db.Entry(canton).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CantonExists(id))
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

        // POST: api/Cantones
        [ResponseType(typeof(Canton))]
        public IHttpActionResult PostCanton(Canton canton)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Canton.Add(canton);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = canton.ID }, canton);
        }

        // DELETE: api/Cantones/5
        [ResponseType(typeof(Canton))]
        public IHttpActionResult DeleteCanton(int id)
        {
            Canton canton = db.Canton.Find(id);
            if (canton == null)
            {
                return NotFound();
            }

            db.Canton.Remove(canton);
            db.SaveChanges();

            return Ok(canton);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CantonExists(int id)
        {
            return db.Canton.Count(e => e.ID == id) > 0;
        }
    }
}