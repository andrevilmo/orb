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
    builder.EntitySet<DadoAcessorio>("DadoAcessorio");
    builder.EntitySet<DadoLido>("DadoLidoes"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DadoAcessorioController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

        // GET odata/DadoAcessorio
        [Queryable]
        public IQueryable<DadoAcessorio> GetDadoAcessorio()
        {
            return db.DadoAcessorios;
        }

        // GET odata/DadoAcessorio(5)
        [Queryable]
        public SingleResult<DadoAcessorio> GetDadoAcessorio([FromODataUri] int key)
        {
            return SingleResult.Create(db.DadoAcessorios.Where(dadoacessorio => dadoacessorio.idDadoAcessorio == key));
        }

        // PUT odata/DadoAcessorio(5)
        public IHttpActionResult Put([FromODataUri] int key, DadoAcessorio dadoacessorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != dadoacessorio.idDadoAcessorio)
            {
                return BadRequest();
            }

            db.Entry(dadoacessorio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadoAcessorioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dadoacessorio);
        }

        // POST odata/DadoAcessorio
        public IHttpActionResult Post(DadoAcessorio dadoacessorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DadoAcessorios.Add(dadoacessorio);
            db.SaveChanges();

            return Created(dadoacessorio);
        }

        // PATCH odata/DadoAcessorio(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DadoAcessorio> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DadoAcessorio dadoacessorio = db.DadoAcessorios.Find(key);
            if (dadoacessorio == null)
            {
                return NotFound();
            }

            patch.Patch(dadoacessorio);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadoAcessorioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dadoacessorio);
        }

        // DELETE odata/DadoAcessorio(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DadoAcessorio dadoacessorio = db.DadoAcessorios.Find(key);
            if (dadoacessorio == null)
            {
                return NotFound();
            }

            db.DadoAcessorios.Remove(dadoacessorio);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/DadoAcessorio(5)/DadoLido
        [Queryable]
        public SingleResult<DadoLido> GetDadoLido([FromODataUri] int key)
        {
            return SingleResult.Create(db.DadoAcessorios.Where(m => m.idDadoAcessorio == key).Select(m => m.DadoLido));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DadoAcessorioExists(int key)
        {
            return db.DadoAcessorios.Count(e => e.idDadoAcessorio == key) > 0;
        }
    }
}
