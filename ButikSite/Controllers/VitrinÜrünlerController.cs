using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class VitrinÜrünlerController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();
        // GET: VitrinÜrünler

        Class1 bgl = new Class1();

        public ActionResult Index()
        {

            bgl.ürn = db.TblÜrünler.Where(x => x.Durum == true).ToList();
            bgl.mrk = db.TblMarkalar.Where(x => x.Durum == true).ToList();
            bgl.ktg = db.TblKategoriler.Where(x => x.Durum == true).ToList();



            return View(bgl);
        }

        public ActionResult Erkek()
        {
            bgl.ürn = db.TblÜrünler.Where(x => x.Durum == true).ToList();
            bgl.mrk = db.TblMarkalar.Where(x => x.Durum == true).ToList();
            bgl.ktg = db.TblKategoriler.Where(x => x.Durum == true).ToList();
            return View(bgl);
        }

        public ActionResult Kadın()
        {
            bgl.ürn = db.TblÜrünler.Where(x => x.Durum == true).ToList();
            bgl.mrk = db.TblMarkalar.Where(x => x.Durum == true).ToList();
            bgl.ktg = db.TblKategoriler.Where(x => x.Durum == true).ToList();
            return View(bgl);

        }

        public ActionResult Çocuk()
        {
            bgl.ürn = db.TblÜrünler.Where(x => x.Durum == true).ToList();
            bgl.mrk = db.TblMarkalar.Where(x => x.Durum == true).ToList();
            bgl.ktg = db.TblKategoriler.Where(x => x.Durum == true).ToList();
            return View(bgl);

        }

        public ActionResult Favoriler(TblFavoriler x)
        {
            var müşteri = (String)Session["Mail"];
            var ürün = db.TblÜrünler.FirstOrDefault(y => y.Id == x.Id);
            //var müşteri = Session["Mail"].ToString();
            var bul = db.TblMüşteriler.FirstOrDefault(y => y.Mail == müşteri);
            x.Müşteri = bul.Id;
            x.Ürün = ürün.Id;
            x.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            
            
            db.TblFavoriler.Add(x);
            db.SaveChanges();
            
            

            return RedirectToAction("Index", "VitrinÜrünler");

        }


        public ActionResult ÜrünDetay(int id)
        {
            bgl.ürn = db.TblÜrünler.Where(x => x.Durum == true).ToList();
            bgl.mrk = db.TblMarkalar.Where(x => x.Durum == true).ToList();
            bgl.ktg = db.TblKategoriler.Where(x => x.Durum == true).ToList();
            bgl.yrm = db.TblYorumlar.Where(x=>x.TblÜrünler.Id==id).ToList();
            var ürün = db.TblÜrünler.Find(id);
            ViewBag.Id = ürün.Id;
            bgl.ürn = db.TblÜrünler.Where(y => y.Id == id).ToList();
            ViewBag.ürünad = ürün.ÜrünAd;
            ViewBag.ürüngörsel = ürün.ÜrünGörsel;
            ViewBag.marka = ürün.TblMarkalar.Marka;
            ViewBag.kategori = ürün.TblKategoriler.KategoriAd;
            ViewBag.fiyat = ürün.SatışFiyat;
            ViewBag.açıklama = ürün.ÜrünBilgi;

            ViewBag.stok = ürün.Stok;
            var deger1 = db.TblYorumlar.Where(x => x.TblÜrünler.Id == id).Count();
            ViewBag.d1 = deger1;
            

            return View(bgl);
        }

        public ActionResult Yorumlar(int id)
        {


            var ürün = db.TblÜrünler.Find(id);
            var bul = db.TblYorumlar.FirstOrDefault(x => x.Ürün == id);



            ViewBag.müşteri = bul.TblMüşteriler.Mail;
            ViewBag.yorum = bul.Yorum;
            ViewBag.konu = bul.Konu;
            ViewBag.tarih = bul.Tarih;

            //var müşteri = db.TblYorumlar.Where(x => x.Ürün == id).Select(y=>y.TblMüşteriler.Mail).FirstOrDefault();
            //ViewBag.müşteri = müşteri;
            return View();
        }

        [HttpGet]
        public ActionResult YorumYap()
        {




            return View();
        }

        [HttpPost]
        public ActionResult YorumYap(TblYorumlar x)
        {
            var mail = (String)Session["Mail"];
            //var ürün = db.TblÜrünler.FirstOrDefault(y => y.Id == x.Id);
           
            var müşteri = db.TblMüşteriler.FirstOrDefault(y => y.Mail == mail);
           
            
            x.Müşteri = müşteri.Id;
            x.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblYorumlar.Add(x);
            db.SaveChanges();

          



            return RedirectToAction("Index", "VitrinÜrünler");
        }


    }
}