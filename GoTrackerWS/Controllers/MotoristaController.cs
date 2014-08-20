using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using GoTrackerWS.Models;

namespace GoTrackerWS.Controllers
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using GoTrackerWS.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Motorista>("Motorista");
    builder.EntitySet<Veiculo>("Veiculo"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class MotoristaController : ODataController
    {
        private GoTrackerWSContext db = new GoTrackerWSContext();

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
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Motorista motorista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != motorista.Id)
            {
                return BadRequest();
            }

            db.Entry(motorista).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> Post(Motorista motorista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motoristas.Add(motorista);
            await db.SaveChangesAsync();

            return Created(motorista);
        }

        // PATCH odata/Motorista(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Motorista> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Motorista motorista = await db.Motoristas.FindAsync(key);
            if (motorista == null)
            {
                return NotFound();
            }

            patch.Patch(motorista);

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Motorista motorista = await db.Motoristas.FindAsync(key);
            if (motorista == null)
            {
                return NotFound();
            }

            db.Motoristas.Remove(motorista);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Motorista(5)/Veiculos
        [Queryable]
        public IQueryable<Veiculo> GetVeiculos([FromODataUri] int key)
        {
            return db.Motoristas.Where(m => m.Id == key).SelectMany(m => m.Veiculos);
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
