using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GoTracker.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /Login/
        [HttpPost]
        public ActionResult Login()
        {
            GoTrackerModel.Models.GoTrackerContainer db = new GoTrackerModel.Models.GoTrackerContainer();
            if (db.Usuarios.Any(x => x.Login.Equals(Request.Params["Login"]) && x.Senha.Equals(Request.Params["Senha"])))
            {
                FormsAuthentication.SetAuthCookie(Request.Params["Login"], true);
                return RedirectToAction("index", "home");
            }
            return View();
        }
    }
}
