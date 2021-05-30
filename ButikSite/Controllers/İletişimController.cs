using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class İletişimController : Controller
    {
        // GET: İletişim
        ButikSiteEntities db = new ButikSiteEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblMesajlar x)
        {

            var musteri = (string)Session["Mail"];
            var bul = db.TblMüşteriler.Where(y => y.Mail == musteri).FirstOrDefault();
            x.Müşteri = bul.Id;
            x.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMesajlar.Add(x);
            db.SaveChanges();

            return View();
        }
    }
}