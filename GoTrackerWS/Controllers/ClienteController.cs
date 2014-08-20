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
    builder.EntitySet<Cliente>("Cliente");
    builder.EntitySet<Usuario>("Usuario"); 
    builder.EntitySet<Veiculo>("Veiculo"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ClienteController : ODataController
    {
        private GoTrackerWSContext db = new GoTrackerWSContext();

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
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != cliente.Id)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> Post(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(cliente);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClienteExists(cliente.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(cliente);
        }

        // PATCH odata/Cliente(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Cliente> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cliente cliente = await db.Clientes.FindAsync(key);
            if (cliente == null)
            {
                return NotFound();
            }

            patch.Patch(cliente);

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Cliente cliente = await db.Clientes.FindAsync(key);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(cliente);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Cliente(5)/ClientePai
        [Queryable]
        public SingleResult<Cliente> GetClientePai([FromODataUri] int key)
        {
            return SingleResult.Create(db.Clientes.Where(m => m.Id == key).Select(m => m.ClientePai));
        }

        // GET odata/Cliente(5)/Clientes
        [Queryable]
        public IQueryable<Cliente> GetClientes([FromODataUri] int key)
        {
            return db.Clientes.Where(m => m.Id == key).SelectMany(m => m.Clientes);
        }

        // GET odata/Cliente(5)/Usuarios
        [Queryable]
        public IQueryable<Usuario> GetUsuarios([FromODataUri] int key)
        {
            return db.Clientes.Where(m => m.Id == key).SelectMany(m => m.Usuarios);
        }

        // GET odata/Cliente(5)/Veiculos
        [Queryable]
        public IQueryable<Veiculo> GetVeiculos([FromODataUri] int key)
        {
            return db.Clientes.Where(m => m.Id == key).SelectMany(m => m.Veiculos);
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
