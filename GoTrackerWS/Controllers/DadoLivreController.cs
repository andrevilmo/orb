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
    builder.EntitySet<DadoLivre>("DadoLivre");
    builder.EntitySet<DadoLido>("DadoLidoes"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DadoLivreController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

        // GET odata/DadoLivre
        [Queryable]
        public IQueryable<DadoLivre> GetDadoLivre()
        {
            return db.DadoLivres;
        }

        // GET odata/DadoLivre(5)
        [Queryable]
        public SingleResult<DadoLivre> GetDadoLivre([FromODataUri] int key)
        {
            return SingleResult.Create(db.DadoLivres.Where(dadolivre => dadolivre.idDadoLivre == key));
        }

        // PUT odata/DadoLivre(5)
        public IHttpActionResult Put([FromODataUri] int key, DadoLivre dadolivre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != dadolivre.idDadoLivre)
            {
                return BadRequest();
            }

            db.Entry(dadolivre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadoLivreExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dadolivre);
        }

        // POST odata/DadoLivre
        public IHttpActionResult Post(DadoLivre dadolivre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DadoLivres.Add(dadolivre);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DadoLivreExists(dadolivre.idDadoLivre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(dadolivre);
        }

        // PATCH odata/DadoLivre(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DadoLivre> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DadoLivre dadolivre = db.DadoLivres.Find(key);
            if (dadolivre == null)
            {
                return NotFound();
            }

            patch.Patch(dadolivre);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadoLivreExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dadolivre);
        }

        // DELETE odata/DadoLivre(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DadoLivre dadolivre = db.DadoLivres.Find(key);
            if (dadolivre == null)
            {
                return NotFound();
            }

            db.DadoLivres.Remove(dadolivre);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/DadoLivre(5)/DadoLido
        [Queryable]
        public SingleResult<DadoLido> GetDadoLido([FromODataUri] int key)
        {
            return SingleResult.Create(db.DadoLivres.Where(m => m.idDadoLivre == key).Select(m => m.DadoLido));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DadoLivreExists(int key)
        {
            return db.DadoLivres.Count(e => e.idDadoLivre == key) > 0;
        }
    }
}
