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
    builder.EntitySet<DadoSatelite>("DadoSatelite");
    builder.EntitySet<DadoLido>("DadoLidoes"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DadoSateliteController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

        // GET odata/DadoSatelite
        [Queryable]
        public IQueryable<DadoSatelite> GetDadoSatelite()
        {
            return db.DadoSatelites;
        }

        // GET odata/DadoSatelite(5)
        [Queryable]
        public SingleResult<DadoSatelite> GetDadoSatelite([FromODataUri] int key)
        {
            return SingleResult.Create(db.DadoSatelites.Where(dadosatelite => dadosatelite.idDadoSatelite == key));
        }

        // PUT odata/DadoSatelite(5)
        public IHttpActionResult Put([FromODataUri] int key, DadoSatelite dadosatelite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != dadosatelite.idDadoSatelite)
            {
                return BadRequest();
            }

            db.Entry(dadosatelite).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadoSateliteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dadosatelite);
        }

        // POST odata/DadoSatelite
        public IHttpActionResult Post(DadoSatelite dadosatelite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DadoSatelites.Add(dadosatelite);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DadoSateliteExists(dadosatelite.idDadoSatelite))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(dadosatelite);
        }

        // PATCH odata/DadoSatelite(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DadoSatelite> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DadoSatelite dadosatelite = db.DadoSatelites.Find(key);
            if (dadosatelite == null)
            {
                return NotFound();
            }

            patch.Patch(dadosatelite);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadoSateliteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dadosatelite);
        }

        // DELETE odata/DadoSatelite(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DadoSatelite dadosatelite = db.DadoSatelites.Find(key);
            if (dadosatelite == null)
            {
                return NotFound();
            }

            db.DadoSatelites.Remove(dadosatelite);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/DadoSatelite(5)/DadoLido
        [Queryable]
        public SingleResult<DadoLido> GetDadoLido([FromODataUri] int key)
        {
            return SingleResult.Create(db.DadoSatelites.Where(m => m.idDadoSatelite == key).Select(m => m.DadoLido));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DadoSateliteExists(int key)
        {
            return db.DadoSatelites.Count(e => e.idDadoSatelite == key) > 0;
        }
    }
}
