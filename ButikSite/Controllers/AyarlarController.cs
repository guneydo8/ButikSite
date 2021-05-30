using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        ButikSiteEntities db = new ButikSiteEntities();
        public ActionResult Index()
        {
            var liste = db.TblAdmin.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblAdmin x)
        {
            db.TblAdmin.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var sil = db.TblAdmin.Find(id);
            db.TblAdmin.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.TblAdmin.Find(id);
            return View(bul);
        }

        public ActionResult Güncelle2(TblAdmin x)
        {
            var gnc = db.TblAdmin.Find(x.Id);
            gnc.Mail = x.Mail;
            gnc.Şifre = x.Şifre;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}