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
    builder.EntitySet<Perfil>("Perfil");
    builder.EntitySet<Usuario>("Usuario"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PerfilController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

        // GET odata/Perfil
        [Queryable]
        public IQueryable<Perfil> GetPerfil()
        {
            return db.Perfils;
        }

        // GET odata/Perfil(5)
        [Queryable]
        public SingleResult<Perfil> GetPerfil([FromODataUri] int key)
        {
            return SingleResult.Create(db.Perfils.Where(perfil => perfil.Id == key));
        }

        // PUT odata/Perfil(5)
        public IHttpActionResult Put([FromODataUri] int key, Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != perfil.Id)
            {
                return BadRequest();
            }

            db.Entry(perfil).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(perfil);
        }

        // POST odata/Perfil
        public IHttpActionResult Post(Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Perfils.Add(perfil);
            db.SaveChanges();

            return Created(perfil);
        }

        // PATCH odata/Perfil(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Perfil> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Perfil perfil = db.Perfils.Find(key);
            if (perfil == null)
            {
                return NotFound();
            }

            patch.Patch(perfil);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(perfil);
        }

        // DELETE odata/Perfil(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Perfil perfil = db.Perfils.Find(key);
            if (perfil == null)
            {
                return NotFound();
            }

            db.Perfils.Remove(perfil);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Perfil(5)/Usuarios
        [Queryable]
        public IQueryable<Usuario> GetUsuarios([FromODataUri] int key)
        {
            return db.Perfils.Where(m => m.Id == key).SelectMany(m => m.Usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerfilExists(int key)
        {
            return db.Perfils.Count(e => e.Id == key) > 0;
        }
    }
}
