using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using GoTrackerModel.Models;

namespace GoTrackerWS.Controllers
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using GoTrackerModel.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Motorista>("Motorista");
    builder.EntitySet<Cliente>("Clientes"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class MotoristaController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

        // GET odata/Motorista
        [Queryable]
        public IQueryable<Motorista> GetMotorista()
        {
            return db.Motoristas;
        }

        // GET odata/Motorista(5)
        [Queryable]
        public SingleResult<Motorista> GetMotorista([FromODataUri] int key)
        {
            return SingleResult.Create(db.Motoristas.Where(motorista => motorista.Id == key));
        }

        // PUT odata/Motorista(5)
        public IHttpActionResult Put([FromODataUri] int key, Motorista motorista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != motorista.Id)
            {
                return BadRequest();
            }

            db.Entry(motorista).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoristaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(motorista);
        }

        // POST odata/Motorista
        public IHttpActionResult Post(Motorista motorista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motoristas.Add(motorista);
            db.SaveChanges();

            return Created(motorista);
        }

        // PATCH odata/Motorista(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Motorista> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Motorista motorista = db.Motoristas.Find(key);
            if (motorista == null)
            {
                return NotFound();
            }

            patch.Patch(motorista);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoristaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(motorista);
        }

        // DELETE odata/Motorista(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Motorista motorista = db.Motoristas.Find(key);
            if (motorista == null)
            {
                return NotFound();
            }

            db.Motoristas.Remove(motorista);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Motorista(5)/Cliente
        [Queryable]
        public SingleResult<Cliente> GetCliente([FromODataUri] int key)
        {
            return SingleResult.Create(db.Motoristas.Where(m => m.Id == key).Select(m => m.Cliente));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MotoristaExists(int key)
        {
            return db.Motoristas.Count(e => e.Id == key) > 0;
        }
    }
}
