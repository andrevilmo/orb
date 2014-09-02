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
using GoTrackerWS.Models;

namespace GoTrackerWS.Controllers
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using GoTrackerWS.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Equipamento>("Equipamento");
    builder.EntitySet<Veiculo>("Veiculo"); 
    builder.EntitySet<SimCard>("SimCards"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EquipamentoController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

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
        public IHttpActionResult Put([FromODataUri] int key, Equipamento equipamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != equipamento.Id)
            {
                return BadRequest();
            }

            db.Entry(equipamento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult Post(Equipamento equipamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Equipamentoes.Add(equipamento);
            db.SaveChanges();

            return Created(equipamento);
        }

        // PATCH odata/Equipamento(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Equipamento> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Equipamento equipamento = db.Equipamentoes.Find(key);
            if (equipamento == null)
            {
                return NotFound();
            }

            patch.Patch(equipamento);

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Equipamento equipamento = db.Equipamentoes.Find(key);
            if (equipamento == null)
            {
                return NotFound();
            }

            db.Equipamentoes.Remove(equipamento);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Equipamento(5)/Veiculoes
        [Queryable]
        public IQueryable<Veiculo> GetVeiculoes([FromODataUri] int key)
        {
            return db.Equipamentoes.Where(m => m.Id == key).SelectMany(m => m.Veiculoes);
        }

        // GET odata/Equipamento(5)/SimCard
        [Queryable]
        public SingleResult<SimCard> GetSimCard([FromODataUri] int key)
        {
            return SingleResult.Create(db.Equipamentoes.Where(m => m.Id == key).Select(m => m.SimCard));
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
