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
    builder.EntitySet<DadoLido>("DadoLido");
    builder.EntitySet<DadoAcessorio>("DadoAcessorio"); 
    builder.EntitySet<DadoAdicional_MXT>("DadoAdicional_MXT"); 
    builder.EntitySet<DadoGSM>("DadoGSM"); 
    builder.EntitySet<DadoLivre>("DadoLivre"); 
    builder.EntitySet<DadoSatelite>("DadoSatelite"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DadoLidoController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

        // GET odata/DadoLido
        [Queryable]
        public IQueryable<DadoLido> GetDadoLido()
        {
            return db.DadoLidoes;
        }

        // GET odata/DadoLido(5)
        [Queryable]
        public SingleResult<DadoLido> GetDadoLido([FromODataUri] int key)
        {
            return SingleResult.Create(db.DadoLidoes.Where(dadolido => dadolido.idDadoLido == key));
        }

        // PUT odata/DadoLido(5)
        public IHttpActionResult Put([FromODataUri] int key, DadoLido dadolido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != dadolido.idDadoLido)
            {
                return BadRequest();
            }

            db.Entry(dadolido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadoLidoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dadolido);
        }

        // POST odata/DadoLido
        public IHttpActionResult Post(DadoLido dadolido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DadoLidoes.Add(dadolido);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DadoLidoExists(dadolido.idDadoLido))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(dadolido);
        }

        // PATCH odata/DadoLido(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DadoLido> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DadoLido dadolido = db.DadoLidoes.Find(key);
            if (dadolido == null)
            {
                return NotFound();
            }

            patch.Patch(dadolido);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadoLidoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dadolido);
        }

        // DELETE odata/DadoLido(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DadoLido dadolido = db.DadoLidoes.Find(key);
            if (dadolido == null)
            {
                return NotFound();
            }

            db.DadoLidoes.Remove(dadolido);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/DadoLido(5)/DadoAcessorios
        [Queryable]
        public IQueryable<DadoAcessorio> GetDadoAcessorios([FromODataUri] int key)
        {
            return db.DadoLidoes.Where(m => m.idDadoLido == key).SelectMany(m => m.DadoAcessorios);
        }

        // GET odata/DadoLido(5)/DadoAdicional_MXT
        [Queryable]
        public IQueryable<DadoAdicional_MXT> GetDadoAdicional_MXT([FromODataUri] int key)
        {
            return db.DadoLidoes.Where(m => m.idDadoLido == key).SelectMany(m => m.DadoAdicional_MXT);
        }

        // GET odata/DadoLido(5)/DadoGSMs
        [Queryable]
        public IQueryable<DadoGSM> GetDadoGSMs([FromODataUri] int key)
        {
            return db.DadoLidoes.Where(m => m.idDadoLido == key).SelectMany(m => m.DadoGSMs);
        }

        // GET odata/DadoLido(5)/DadoLivres
        [Queryable]
        public IQueryable<DadoLivre> GetDadoLivres([FromODataUri] int key)
        {
            return db.DadoLidoes.Where(m => m.idDadoLido == key).SelectMany(m => m.DadoLivres);
        }

        // GET odata/DadoLido(5)/DadoSatelites
        [Queryable]
        public IQueryable<DadoSatelite> GetDadoSatelites([FromODataUri] int key)
        {
            return db.DadoLidoes.Where(m => m.idDadoLido == key).SelectMany(m => m.DadoSatelites);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DadoLidoExists(int key)
        {
            return db.DadoLidoes.Count(e => e.idDadoLido == key) > 0;
        }
    }
}
