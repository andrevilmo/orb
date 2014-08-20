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
    builder.EntitySet<Equipamento>("Equipamento");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EquipamentoController : ODataController
    {
        private GoTrackerWSContext db = new GoTrackerWSContext();

        // GET odata/Equipamento
        [Queryable]
        public IQueryable<Equipamento> GetEquipamento()
        {
            return db.Equipamentoes;
        }

        // GET odata/Equipamento(5)
        [Queryable]
        public SingleResult<Equipamento> GetEquipamento([FromODataUri] int key)
        {
            return SingleResult.Create(db.Equipamentoes.Where(equipamento => equipamento.Id == key));
        }

        // PUT odata/Equipamento(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Equipamento equipamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != equipamento.Id)
            {
                return BadRequest();
            }

            db.Entry(equipamento).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipamentoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(equipamento);
        }

        // POST odata/Equipamento
        public async Task<IHttpActionResult> Post(Equipamento equipamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Equipamentoes.Add(equipamento);
            await db.SaveChangesAsync();

            return Created(equipamento);
        }

        // PATCH odata/Equipamento(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Equipamento> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Equipamento equipamento = await db.Equipamentoes.FindAsync(key);
            if (equipamento == null)
            {
                return NotFound();
            }

            patch.Patch(equipamento);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipamentoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(equipamento);
        }

        // DELETE odata/Equipamento(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Equipamento equipamento = await db.Equipamentoes.FindAsync(key);
            if (equipamento == null)
            {
                return NotFound();
            }

            db.Equipamentoes.Remove(equipamento);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EquipamentoExists(int key)
        {
            return db.Equipamentoes.Count(e => e.Id == key) > 0;
        }
    }
}
