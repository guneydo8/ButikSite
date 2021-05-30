using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;
namespace ButikSite.Controllers
{
    public class MüşterilerController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();
        // GET: Müşteriler
        public ActionResult Liste()
        {
            var liste = db.TblMüşteriler.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblMüşteriler x)
        {
            db.TblMüşteriler.Add(x);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Sil(int id)
        {
            var bul = db.TblMüşteriler.Find(id);
            db.TblMüşteriler.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.TblMüşteriler.Find(id);
            return View(bul);
        }

        public ActionResult Güncelle2(TblMüşteriler x)
        {
            var gnc = db.TblMüşteriler.Find(x.Id);
            gnc.Ad = x.Ad;
            gnc.Adres = x.Adres;
            gnc.Mail = x.Mail;
            gnc.Soyad = x.Soyad;
            gnc.Telefon = x.Telefon;
            gnc.Şifre = x.Şifre;
            db.SaveChanges();
            return RedirectToAction("Liste");
        }
    }
}