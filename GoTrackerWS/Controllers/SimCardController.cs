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
    builder.EntitySet<SimCard>("SimCard");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SimCardController : ODataController
    {
        private GoTrackerWSContext db = new GoTrackerWSContext();

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
        public async Task<IHttpActionResult> Put([FromODataUri] int key, SimCard simcard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != simcard.Id)
            {
                return BadRequest();
            }

            db.Entry(simcard).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> Post(SimCard simcard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SimCards.Add(simcard);
            await db.SaveChangesAsync();

            return Created(simcard);
        }

        // PATCH odata/SimCard(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<SimCard> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SimCard simcard = await db.SimCards.FindAsync(key);
            if (simcard == null)
            {
                return NotFound();
            }

            patch.Patch(simcard);

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            SimCard simcard = await db.SimCards.FindAsync(key);
            if (simcard == null)
            {
                return NotFound();
            }

            db.SimCards.Remove(simcard);
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

        private bool SimCardExists(int key)
        {
            return db.SimCards.Count(e => e.Id == key) > 0;
        }
    }
}
