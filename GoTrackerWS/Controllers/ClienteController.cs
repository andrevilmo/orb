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
using GoTrackerWS.Models;

namespace GoTrackerWS.Controllers
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using GoTrackerWS.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Cliente>("Cliente");
    builder.EntitySet<Veiculo>("Veiculo"); 
    builder.EntitySet<Usuario>("Usuario"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ClienteController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

        // GET odata/Cliente
        [Queryable]
        public IQueryable<Cliente> GetCliente()
        {
            return db.Clientes;
        }

        // GET odata/Cliente(5)
        [Queryable]
        public SingleResult<Cliente> GetCliente([FromODataUri] int key)
        {
            return SingleResult.Create(db.Clientes.Where(cliente => cliente.Id == key));
        }

        // PUT odata/Cliente(5)
        public IHttpActionResult Put([FromODataUri] int key, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != cliente.Id)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cliente);
        }

        // POST odata/Cliente
        public IHttpActionResult Post(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(cliente);
            db.SaveChanges();

            return Created(cliente);
        }

        // PATCH odata/Cliente(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Cliente> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cliente cliente = db.Clientes.Find(key);
            if (cliente == null)
            {
                return NotFound();
            }

            patch.Patch(cliente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cliente);
        }

        // DELETE odata/Cliente(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Cliente cliente = db.Clientes.Find(key);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(cliente);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Cliente(5)/Veiculoes
        [Queryable]
        public IQueryable<Veiculo> GetVeiculoes([FromODataUri] int key)
        {
            return db.Clientes.Where(m => m.Id == key).SelectMany(m => m.Veiculoes);
        }

        // GET odata/Cliente(5)/ClientePai
        [Queryable]
        public SingleResult<Cliente> GetClientePai([FromODataUri] int key)
        {
            return SingleResult.Create(db.Clientes.Where(m => m.Id == key).Select(m => m.ClientePai));
        }

        // GET odata/Cliente(5)/ClienteFilhoDe
        [Queryable]
        public SingleResult<Cliente> GetClienteFilhoDe([FromODataUri] int key)
        {
            return SingleResult.Create(db.Clientes.Where(m => m.Id == key).Select(m => m.ClienteFilhoDe));
        }

        // GET odata/Cliente(5)/Usuarios
        [Queryable]
        public IQueryable<Usuario> GetUsuarios([FromODataUri] int key)
        {
            return db.Clientes.Where(m => m.Id == key).SelectMany(m => m.Usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int key)
        {
            return db.Clientes.Count(e => e.Id == key) > 0;
        }
    }
}
