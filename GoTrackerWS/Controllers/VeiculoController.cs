﻿using System;
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
    builder.EntitySet<Veiculo>("Veiculo");
    builder.EntitySet<Cliente>("Clientes"); 
    builder.EntitySet<Equipamento>("Equipamentoes"); 
    builder.EntitySet<Motorista>("Motoristas"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class VeiculoController : ODataController
    {
        private GoTrackerContainer db = new GoTrackerContainer();

        // GET odata/Veiculo
        [Queryable]
        public IQueryable<Veiculo> GetVeiculo()
        {
            return db.Veiculoes;
        }

        // GET odata/Veiculo(5)
        [Queryable]
        public SingleResult<Veiculo> GetVeiculo([FromODataUri] int key)
        {
            return SingleResult.Create(db.Veiculoes.Where(veiculo => veiculo.Id == key));
        }

        // PUT odata/Veiculo(5)
        public IHttpActionResult Put([FromODataUri] int key, Veiculo veiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != veiculo.Id)
            {
                return BadRequest();
            }

            db.Entry(veiculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(veiculo);
        }

        // POST odata/Veiculo
        public IHttpActionResult Post(Veiculo veiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Veiculoes.Add(veiculo);
            db.SaveChanges();

            return Created(veiculo);
        }

        // PATCH odata/Veiculo(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Veiculo> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Veiculo veiculo = db.Veiculoes.Find(key);
            if (veiculo == null)
            {
                return NotFound();
            }

            patch.Patch(veiculo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(veiculo);
        }

        // DELETE odata/Veiculo(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Veiculo veiculo = db.Veiculoes.Find(key);
            if (veiculo == null)
            {
                return NotFound();
            }

            db.Veiculoes.Remove(veiculo);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Veiculo(5)/Cliente
        [Queryable]
        public SingleResult<Cliente> GetCliente([FromODataUri] int key)
        {
            return SingleResult.Create(db.Veiculoes.Where(m => m.Id == key).Select(m => m.Cliente));
        }

        // GET odata/Veiculo(5)/Equipamento
        [Queryable]
        public SingleResult<Equipamento> GetEquipamento([FromODataUri] int key)
        {
            return SingleResult.Create(db.Veiculoes.Where(m => m.Id == key).Select(m => m.Equipamento));
        }

        // GET odata/Veiculo(5)/Motorista
        [Queryable]
        public SingleResult<Motorista> GetMotorista([FromODataUri] int key)
        {
            return SingleResult.Create(db.Veiculoes.Where(m => m.Id == key).Select(m => m.Motorista));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VeiculoExists(int key)
        {
            return db.Veiculoes.Count(e => e.Id == key) > 0;
        }
    }
}
