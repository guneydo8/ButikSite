using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class DuyurularController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();
        // GET: Duyurular
        public ActionResult Liste()
        {
            var liste = db.TblDuyurular.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblDuyurular x)
        {
            x.Tarih =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblDuyurular.Add(x);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Sil(int id)
        {
            var bul = db.TblDuyurular.Find(id);
            db.TblDuyurular.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.TblDuyurular.Find(id);
            return View(bul);
        }
        public ActionResult Güncelle2(TblDuyurular x)
        {
            var gnc = db.TblDuyurular.Find(x.Id);
            gnc.DuyuruBaşlık = x.DuyuruBaşlık;
            gnc.Duyuruİçerik = x.Duyuruİçerik;
            
            db.SaveChanges();
            return RedirectToAction("Liste");
        }
    }
}