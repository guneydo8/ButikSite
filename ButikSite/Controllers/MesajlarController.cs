using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class MesajlarController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();
        // GET: Mesajlar
        public ActionResult GelenKutusu()
        {
            var liste = db.TblMesajlar.ToList();

            return View(liste);
        }

        public ActionResult Detay(int id)
        {
            var bul = db.TblMesajlar.Find(id);
            
            return View(bul);
        }

        [HttpGet]
        public ActionResult YeniMesaj(int id)
        {
            var bul = db.TblMesajlar.Find(id);
            bul.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            bul.Başlık = "";
            bul.İçerik = "";
        
            return View(bul);
        }

        [HttpPost]
        public ActionResult YeniMesaj(TblMesajlar x)
        {
            
            

            db.TblMesajlar.Add(x);
           

            db.SaveChanges();
            return RedirectToAction("GelenKutusu");
        }
    }
}