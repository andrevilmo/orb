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
    builder.EntitySet<DadoGSM>("DadoGSM");
    builder.EntitySet<DadoLido>("DadoLidoes"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DadoGSMController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

        // GET odata/DadoGSM
        [Queryable]
        public IQueryable<DadoGSM> GetDadoGSM()
        {
            return db.DadoGSMs;
        }

        // GET odata/DadoGSM(5)
        [Queryable]
        public SingleResult<DadoGSM> GetDadoGSM([FromODataUri] int key)
        {
            return SingleResult.Create(db.DadoGSMs.Where(dadogsm => dadogsm.idDadoGSM == key));
        }

        // PUT odata/DadoGSM(5)
        public IHttpActionResult Put([FromODataUri] int key, DadoGSM dadogsm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != dadogsm.idDadoGSM)
            {
                return BadRequest();
            }

            db.Entry(dadogsm).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadoGSMExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dadogsm);
        }

        // POST odata/DadoGSM
        public IHttpActionResult Post(DadoGSM dadogsm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DadoGSMs.Add(dadogsm);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DadoGSMExists(dadogsm.idDadoGSM))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(dadogsm);
        }

        // PATCH odata/DadoGSM(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DadoGSM> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DadoGSM dadogsm = db.DadoGSMs.Find(key);
            if (dadogsm == null)
            {
                return NotFound();
            }

            patch.Patch(dadogsm);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadoGSMExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dadogsm);
        }

        // DELETE odata/DadoGSM(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DadoGSM dadogsm = db.DadoGSMs.Find(key);
            if (dadogsm == null)
            {
                return NotFound();
            }

            db.DadoGSMs.Remove(dadogsm);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/DadoGSM(5)/DadoLido
        [Queryable]
        public SingleResult<DadoLido> GetDadoLido([FromODataUri] int key)
        {
            return SingleResult.Create(db.DadoGSMs.Where(m => m.idDadoGSM == key).Select(m => m.DadoLido));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DadoGSMExists(int key)
        {
            return db.DadoGSMs.Count(e => e.idDadoGSM == key) > 0;
        }
    }
}
