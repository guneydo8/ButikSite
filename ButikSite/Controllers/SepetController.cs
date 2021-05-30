using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class SepetController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();


        // GET: Sepet
        Class1 bgl = new Class1();

        public ActionResult Liste()
        {


            var mail = (string)Session["Mail"];
            var bul = db.TblMüşteriler.FirstOrDefault(y => y.Mail == mail);
            var bul2 = bul.Id;
           

            bgl.spt = db.TblSepetim.Where(y => y.TblMüşteriler.Mail == mail).ToList();
            var toplam = db.TblSepetim.Where(y => y.Müşteri == bul2).Sum(z => z.TblÜrünler.SatışFiyat);

            if (toplam == null)
            {
                ViewBag.d1 = "Sepetinizde Ürün Bulunmuyor";
            }

            else if(toplam!=null)
            {
                ViewBag.d1 = toplam;
            }
           
            return View(bgl);
        }

     

        [HttpGet]
        public ActionResult Satış()
        {

            var mail = (string)Session["Mail"];
            var bul = db.TblMüşteriler.FirstOrDefault(y => y.Mail == mail);
            var sepet = db.TblSepetim.Where(x=>x.Müşteri==bul.Id).Include(x=>x.TblÜrünler).ToList();
            decimal fiyat = 0;
            foreach (var item in sepet)
            {
                fiyat += item.TblÜrünler.SatışFiyat.Value;
              
                var satis = new TblSatışlar { Adet = 1, Fiyat = fiyat, Müşteri = bul.Id, SiparişNot = "", Tarih = DateTime.Now, Ürün = item.TblÜrünler.Id };
                db.TblSatışlar.Add(satis);
                db.TblSepetim.Remove(item);

            }
            db.SaveChanges();
            return RedirectToAction("Liste", "Sepet");
        }
        public ActionResult SepeteEkle(int id) {
            
            var mail = (string)Session["Mail"];
           
            var bul = db.TblMüşteriler.FirstOrDefault(y => y.Mail == mail);
            TblSepetim sepet = new TblSepetim() { Müşteri = bul.Id, Tarih = DateTime.Now, Ürün = id };
            db.TblSepetim.Add(sepet);
            db.SaveChanges();
            return RedirectToAction("Liste", "Sepet");

        }
        public ActionResult SepettenCikar(int id)
        {

            var mail = (string)Session["Mail"];
            var bul = db.TblMüşteriler.FirstOrDefault(y => y.Mail == mail);
            TblSepetim sepet = db.TblSepetim.Where(x => x.Ürün == id && x.Müşteri == bul.Id).FirstOrDefault();
            if (sepet != null) {
                db.TblSepetim.Remove(sepet);
                db.SaveChanges();

            }
            return RedirectToAction("Liste", "Sepet");

        }


        public ActionResult FavoriListe()
        {
          
           

            var mail = (string)Session["Mail"];
            var bul = db.TblMüşteriler.FirstOrDefault(x => x.Mail == mail);
            
            bgl.fvr = db.TblFavoriler.Where(x => x.Müşteri == bul.Id).ToList();

          
            
            return View(bgl);
        }

        public ActionResult FavoridenÇıkar(int id)
        {
            var mail = (string)Session["Mail"];
            var bul = db.TblMüşteriler.FirstOrDefault(x => x.Mail == mail);
            TblFavoriler favori = db.TblFavoriler.Where(x => x.Müşteri == bul.Id && x.Ürün == id).FirstOrDefault();
            db.TblFavoriler.Remove(favori);
            db.SaveChanges();



            return RedirectToAction("FavoriListe","Sepet");
        }

    }
}