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
    public class PedidoesController : ApiController
    {
        private ARE_EskolorEntities db = new ARE_EskolorEntities();

        // GET: api/Pedidoes
        public IQueryable<Pedido> GetPedido()
        {
            return db.Pedido;
        }

        // GET: api/Pedidoes/5
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult GetPedido(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        // PUT: api/Pedidoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedido(int id, Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedido.ID)
            {
                return BadRequest();
            }

            db.Entry(pedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        // POST: api/Pedidoes
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult PostPedido(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedido.Add(pedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedido.ID }, pedido);
        }

        // DELETE: api/Pedidoes/5
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult DeletePedido(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }

            db.Pedido.Remove(pedido);
            db.SaveChanges();

            return Ok(pedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoExists(int id)
        {
            return db.Pedido.Count(e => e.ID == id) > 0;
        }
    }
}