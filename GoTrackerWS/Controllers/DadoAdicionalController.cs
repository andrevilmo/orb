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
    builder.EntitySet<DadoAdicional_MXT>("DadoAdicional");
    builder.EntitySet<DadoLido>("DadoLidoes"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DadoAdicionalController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

        // GET odata/DadoAdicional
        [Queryable]
        public IQueryable<DadoAdicional_MXT> GetDadoAdicional()
        {
            return db.DadoAdicional_MXT;
        }

        // GET odata/DadoAdicional(5)
        [Queryable]
        public SingleResult<DadoAdicional_MXT> GetDadoAdicional_MXT([FromODataUri] int key)
        {
            return SingleResult.Create(db.DadoAdicional_MXT.Where(dadoadicional_mxt => dadoadicional_mxt.idDadoAdicional == key));
        }

        // PUT odata/DadoAdicional(5)
        public IHttpActionResult Put([FromODataUri] int key, DadoAdicional_MXT dadoadicional_mxt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != dadoadicional_mxt.idDadoAdicional)
            {
                return BadRequest();
            }

            db.Entry(dadoadicional_mxt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadoAdicional_MXTExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dadoadicional_mxt);
        }

        // POST odata/DadoAdicional
        public IHttpActionResult Post(DadoAdicional_MXT dadoadicional_mxt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DadoAdicional_MXT.Add(dadoadicional_mxt);
            db.SaveChanges();

            return Created(dadoadicional_mxt);
        }

        // PATCH odata/DadoAdicional(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DadoAdicional_MXT> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DadoAdicional_MXT dadoadicional_mxt = db.DadoAdicional_MXT.Find(key);
            if (dadoadicional_mxt == null)
            {
                return NotFound();
            }

            patch.Patch(dadoadicional_mxt);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadoAdicional_MXTExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dadoadicional_mxt);
        }

        // DELETE odata/DadoAdicional(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DadoAdicional_MXT dadoadicional_mxt = db.DadoAdicional_MXT.Find(key);
            if (dadoadicional_mxt == null)
            {
                return NotFound();
            }

            db.DadoAdicional_MXT.Remove(dadoadicional_mxt);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/DadoAdicional(5)/DadoLido
        [Queryable]
        public SingleResult<DadoLido> GetDadoLido([FromODataUri] int key)
        {
            return SingleResult.Create(db.DadoAdicional_MXT.Where(m => m.idDadoAdicional == key).Select(m => m.DadoLido));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DadoAdicional_MXTExists(int key)
        {
            return db.DadoAdicional_MXT.Count(e => e.idDadoAdicional == key) > 0;
        }
    }
}
