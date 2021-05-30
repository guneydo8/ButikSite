using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class LoginController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();
        // GET: Login
        public ActionResult Giriş()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giriş(TblMüşteriler x)
        {
            var giriş = db.TblMüşteriler.FirstOrDefault(y => y.Mail == x.Mail && y.Şifre == x.Şifre);

            if (giriş != null)
            {
                FormsAuthentication.SetAuthCookie(giriş.Mail, false);
                Session["Mail"] = giriş.Mail;
                Session["Name"] = giriş.Ad + " " + giriş.Soyad;
                return RedirectToAction("Index", "VitrinAnasayfa");
            }

            else
            {
                return View();
            }
        }

        public ActionResult KayıtOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KayıtOl(TblMüşteriler x)
        {
            x.Durum = true;
            db.TblMüşteriler.Add(x);
            db.SaveChanges();
            return RedirectToAction("Giriş", "Login");


        }

        public ActionResult ÇıkışYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giriş", "Login");
        }
    }
}