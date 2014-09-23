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
    builder.EntitySet<SimCard>("SimCard");
    builder.EntitySet<Equipamento>("Equipamento"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SimCardController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

        // GET odata/SimCard
        [Queryable]
        public IQueryable<SimCard> GetSimCard()
        {
            return db.SimCards;
        }

        // GET odata/SimCard(5)
        [Queryable]
        public SingleResult<SimCard> GetSimCard([FromODataUri] int key)
        {
            return SingleResult.Create(db.SimCards.Where(simcard => simcard.Id == key));
        }

        // PUT odata/SimCard(5)
        public IHttpActionResult Put([FromODataUri] int key, SimCard simcard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != simcard.Id)
            {
                return BadRequest();
            }

            db.Entry(simcard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimCardExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(simcard);
        }

        // POST odata/SimCard
        public IHttpActionResult Post(SimCard simcard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SimCards.Add(simcard);
            db.SaveChanges();

            return Created(simcard);
        }

        // PATCH odata/SimCard(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<SimCard> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SimCard simcard = db.SimCards.Find(key);
            if (simcard == null)
            {
                return NotFound();
            }

            patch.Patch(simcard);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimCardExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(simcard);
        }

        // DELETE odata/SimCard(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            SimCard simcard = db.SimCards.Find(key);
            if (simcard == null)
            {
                return NotFound();
            }

            db.SimCards.Remove(simcard);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/SimCard(5)/Equipamentoes
        [Queryable]
        public IQueryable<Equipamento> GetEquipamentoes([FromODataUri] int key)
        {
            return db.SimCards.Where(m => m.Id == key).SelectMany(m => m.Equipamentoes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SimCardExists(int key)
        {
            return db.SimCards.Count(e => e.Id == key) > 0;
        }
    }
}
