using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GoTracker.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        //[HttpPost]
        public ActionResult Index()
        {
            GoTrackerModel.Models.GoTrackerContainer db = new GoTrackerModel.Models.GoTrackerContainer();
            string s_user = Request.Params["Login"];
            string s_pwd = Request.Params["Senha"];
            if (null != s_user && null != s_pwd) 
            {
                if (db.Usuarios.Any(x => x.Login == s_user && x.Senha == s_pwd)||
                    (System.Configuration.ConfigurationManager.AppSettings["UsuarioAdmin"].Equals(s_user)&&
                     System.Configuration.ConfigurationManager.AppSettings["SenhaAdmin"].Equals(s_user)))
                {
                    FormsAuthentication.SetAuthCookie(Request.Params["Login"], true);
                    if (Request.Params["ReturnUrl"] == null || 
                        (Request.Params["ReturnUrl"] != null && Request.Params["ReturnUrl"].ToString().Trim().ToLower().Equals("/logout")) )
                        return RedirectToAction("index", "home");
                    else
                        Response.Redirect(Request.Params["ReturnUrl"]);
                }
            }
            return View();
        }
    }
}
