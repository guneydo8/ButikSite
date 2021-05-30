using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;
using PagedList.Mvc;
using PagedList;


namespace ButikSite.Controllers
{
    public class ÜrünlerController : Controller
    {
        // GET: Ürünler
        ButikSiteEntities db = new ButikSiteEntities();
        public ActionResult Liste(int sayfa=1)
        {
            var liste = db.TblÜrünler.Where(x=>x.Durum==true).ToList().ToPagedList(sayfa,10);
            return View(liste);
        }
        public ActionResult PartialViewExample()
        {
            Class1 model = new Class1();
            model.ktg = db.TblKategoriler.ToList();

            return PartialView(model);
        }

      


        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> kategori = (from x in db.TblKategoriler
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.Id.ToString()
                                             }

                                               ).ToList();

            ViewBag.ktg = kategori;

            List<SelectListItem> marka = (from x in db.TblMarkalar
                                          select new SelectListItem
                                          {
                                              Text = x.Marka,
                                              Value = x.Id.ToString()
                                          }).ToList();
            ViewBag.mrk = marka;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblÜrünler x)
        {
            var kategori = db.TblKategoriler.Where(y => y.Id == x.TblKategoriler.Id).FirstOrDefault();
            x.TblKategoriler = kategori;

            var marka = db.TblMarkalar.Where(y => y.Id == x.TblMarkalar.Id).FirstOrDefault();
            x.TblMarkalar = marka;

            db.TblÜrünler.Add(x);
            db.SaveChanges();

            return RedirectToAction("Liste");
        }
        public ActionResult Sil(int Id)
        {
            var bul = db.TblÜrünler.Find(Id);
            //db.TblÜrünler.Remove(bul);
            bul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Liste");

        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.TblÜrünler.Find(id);
            List<SelectListItem> kategori = (from x in db.TblKategoriler
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.Id.ToString()
                                             }).ToList();

            List<SelectListItem> marka = (from x in db.TblMarkalar
                                          select new SelectListItem
                                          {
                                              Text = x.Marka,
                                              Value = x.Id.ToString()
                                          }).ToList();

            ViewBag.ktg = kategori;
            ViewBag.mrk = marka;
            return View(bul);
        }

        public ActionResult Güncelle2(TblÜrünler x)
        {
            var gnc = db.TblÜrünler.Find(x.Id);
            gnc.AlışFiyat = x.AlışFiyat;
            gnc.SatışFiyat = x.SatışFiyat;
            gnc.Stok = x.Stok;
            gnc.ÜrünAd = x.ÜrünAd;
            gnc.ÜrünBilgi = x.ÜrünBilgi;
            gnc.ÜrünGörsel = x.ÜrünGörsel;
            var kategori = db.TblKategoriler.Where(y => y.Id == x.TblKategoriler.Id).FirstOrDefault();
            gnc.Kategori = kategori.Id;
            var marka = db.TblMarkalar.Where(y => y.Id == x.TblMarkalar.Id).FirstOrDefault();
            gnc.Marka = marka.Id;
            db.SaveChanges();
            return RedirectToAction("Liste");

        }
        public ActionResult Görsel(int id)
        {
            //var deger1=db.TblÜrünler.Where(x=>x.Id==id).
            var bul = db.TblÜrünler.Find(id);
            ViewBag.d1 = bul.ÜrünGörsel;
            return View();
        }
    }
}