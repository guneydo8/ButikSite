using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class MarkalarController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();
        // GET: Markalar
        public ActionResult Liste()
        {
            var liste = db.TblMarkalar.Where(x=>x.Durum==true).ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblMarkalar x)
        {
            db.TblMarkalar.Add(x);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Sil(int id)
        {
            var rmv = db.TblMarkalar.Find(id);
            //db.TblMarkalar.Remove(rmv);
            rmv.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Liste");

        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.TblMarkalar.Find(id);
            return View(bul);
        }
        public ActionResult Güncelle2(TblMarkalar x)
        {
            var gnc = db.TblMarkalar.Find(x.Id);
            gnc.Marka = x.Marka;
            db.SaveChanges();
            return RedirectToAction("Liste");
            
        }

        public ActionResult Detay(int id)
        {
            var ürün = db.TblÜrünler.Where(x => x.Marka == id).ToList();
            return View(ürün);
        }
    }
}