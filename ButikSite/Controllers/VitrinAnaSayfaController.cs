using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class VitrinAnaSayfaController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();
        // GET: VitrinAnaSayfa
        public ActionResult Index()
        {
            Class1 bgl = new Class1();
            bgl.ürn = db.TblÜrünler.ToList();
            bgl.ktg = db.TblKategoriler.ToList();
            var deger9 = db.trendler().FirstOrDefault();
            var deger8 = db.trendfiyat().FirstOrDefault();
            var deger7 = db.trendgörsel().FirstOrDefault();


            ViewBag.d9 = deger9;
            ViewBag.d8 = deger8;
            ViewBag.d7 = deger7;



            return View(bgl);
        }

      

        public PartialViewResult partial1()
        {
            var bul = (string)Session["Mail"];

            var müsteri = db.TblMüşteriler.FirstOrDefault(y => y.Mail == bul);


            if (bul == null)
            {
                ViewBag.d1 = 0;
                ViewBag.d2 = 0;
            }

            else
            {

              
                var favori = db.TblFavoriler.Where(y => y.Müşteri == müsteri.Id).Count();
                var sepet = db.TblSepetim.Where(y => y.Müşteri == müsteri.Id).Count();
                ViewBag.d1 = favori;
                ViewBag.d2 = sepet;
            }


          
            return PartialView("partial1");
        }
    }
}