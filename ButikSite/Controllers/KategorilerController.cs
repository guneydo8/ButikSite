using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class KategorilerController : Controller
    {

        // GET: Kategoriler
        ButikSiteEntities db = new ButikSiteEntities();
        public ActionResult Liste()
        {

            var liste = db.TblKategoriler.Where(x=>x.Durum==true).ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Ekle(TblKategoriler x)
        {
            db.TblKategoriler.Add(x);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Sil(int id)
        {
            var bul = db.TblKategoriler.Find(id);

            //db.TblKategoriler.Remove(bul);
            bul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Liste");


        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.TblKategoriler.Find(id);
            return View(bul);
        }

        public ActionResult Güncelle2(TblKategoriler x)
        {
            var gnc = db.TblKategoriler.Find(x.Id);
            gnc.KategoriAd = x.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Detay(int id)
        {
            var bul = db.TblÜrünler.Where(x => x.Kategori == id).ToList();
            return View(bul);
            
        }
    }
}