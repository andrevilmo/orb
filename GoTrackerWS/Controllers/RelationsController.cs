using GoTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace GoTrackerWS.Controllers
{
    public class RelationsController : ApiController
    {
        [HttpPost]
        [AcceptVerbs("POST")]
        [ActionName("Save")]
        public HttpResponseMessage Save()
        {
            GoTrackerContainer db = new GoTrackerContainer();

            if (System.Web.HttpContext.Current.Request.Params["id"] != null &&
                System.Web.HttpContext.Current.Request.Params["id_rel"] != null &&
                System.Web.HttpContext.Current.Request.Params["rel"] != null)
            {

                int id = Convert.ToInt32(System.Web.HttpContext.Current.Request.Params["id"]);
                int id_rel = Convert.ToInt32(System.Web.HttpContext.Current.Request.Params["id_rel"]);
                string rel = System.Web.HttpContext.Current.Request.Params["rel"];

                if (rel.Trim().ToString().Equals("clientefilhode"))
                {
                    var origem = db.Clientes.Where(x => x.Id == id).First();
                    var destino = db.Clientes.Where(x => x.Id == id_rel).First();
                    origem.ClienteFilhoDe = destino;
                    db.Entry(origem).State = EntityState.Modified;
                }
                else if (rel.Trim().ToString().Equals("clientedosimcard"))
                {
                    var origem = db.SimCards.Where(x => x.Id == id).First();
                    var destino = db.Clientes.Where(x => x.Id == id_rel).First();
                    origem.Cliente = destino;
                    db.Entry(origem).State = EntityState.Modified;
                }
                else if (rel.Trim().ToString().Equals("clientedoveiculo"))
                {
                    var origem = db.Motoristas.Where(x => x.Id == id).First();
                    var destino = db.Clientes.Where(x => x.Id == id_rel).First();
                    origem.Cliente = destino;
                    db.Entry(origem).State = EntityState.Modified;
                }
                else if (rel.Trim().ToString().Equals("clientedoequipamento"))
                {
                    var origem = db.Equipamentoes.Where(x => x.Id == id).First();
                    var destino = db.Clientes.Where(x => x.Id == id_rel).First();
                    origem.ClienteId = Int32.Parse( destino.ClienteId );
                    db.Entry(origem).State = EntityState.Modified;
                }
                //clientedoequipamento

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
            }
            return Request.CreateResponse(HttpStatusCode.Created, new Cliente());
        }
    }
}
