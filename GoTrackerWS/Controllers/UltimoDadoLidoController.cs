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
    builder.EntitySet<Ultimo_DadoLido>("UltimoDadoLido");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class UltimoDadoLidoController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

        // GET odata/UltimoDadoLido
        [Queryable]
        public IQueryable<Ultimo_DadoLido> GetUltimoDadoLido()
        {
            return db.Ultimo_DadoLido;
        }

        // GET odata/UltimoDadoLido(5)
        [Queryable]
        public SingleResult<Ultimo_DadoLido> GetUltimo_DadoLido([FromODataUri] int key)
        {
            return SingleResult.Create(db.Ultimo_DadoLido.Where(ultimo_dadolido => ultimo_dadolido.idUltimoDadoLido == key));
        }

        // PUT odata/UltimoDadoLido(5)
        public IHttpActionResult Put([FromODataUri] int key, Ultimo_DadoLido ultimo_dadolido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != ultimo_dadolido.idUltimoDadoLido)
            {
                return BadRequest();
            }

            db.Entry(ultimo_dadolido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ultimo_DadoLidoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(ultimo_dadolido);
        }

        // POST odata/UltimoDadoLido
        public IHttpActionResult Post(Ultimo_DadoLido ultimo_dadolido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ultimo_DadoLido.Add(ultimo_dadolido);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Ultimo_DadoLidoExists(ultimo_dadolido.idUltimoDadoLido))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(ultimo_dadolido);
        }

        // PATCH odata/UltimoDadoLido(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Ultimo_DadoLido> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ultimo_DadoLido ultimo_dadolido = db.Ultimo_DadoLido.Find(key);
            if (ultimo_dadolido == null)
            {
                return NotFound();
            }

            patch.Patch(ultimo_dadolido);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ultimo_DadoLidoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(ultimo_dadolido);
        }

        // DELETE odata/UltimoDadoLido(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Ultimo_DadoLido ultimo_dadolido = db.Ultimo_DadoLido.Find(key);
            if (ultimo_dadolido == null)
            {
                return NotFound();
            }

            db.Ultimo_DadoLido.Remove(ultimo_dadolido);
            db.SaveChanges();

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

        private bool Ultimo_DadoLidoExists(int key)
        {
            return db.Ultimo_DadoLido.Count(e => e.idUltimoDadoLido == key) > 0;
        }
    }
}
