using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ButikSite.Models;
namespace ButikSite.Controllers
{
    public class AdminLoginController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();
        // GET: AdminLogin
        public ActionResult AdminGiriş()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminGiriş(TblAdmin x)
        {
            var giriş = db.TblAdmin.FirstOrDefault(y => y.Mail == x.Mail && y.Şifre == x.Şifre);
            if (giriş != null)
            {
                FormsAuthentication.SetAuthCookie(giriş.Mail, false);
                Session["Mail"] = giriş.Mail.ToString();
                return RedirectToAction("Liste", "Kategoriler");
            }

            else
            {
                return View();
            }
            
        }
        public ActionResult Logout(TblAdmin x)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminGiriş", "AdminLogin");

        }
    }
}