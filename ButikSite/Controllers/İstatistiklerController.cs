using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class İstatistiklerController : Controller
    {
        // GET: İstatistikler
        ButikSiteEntities db = new ButikSiteEntities();
        public ActionResult Liste()
        {
            var deger1 = db.TblMüşteriler.Count();
            var deger2 = db.TblÜrünler.Count();
            var deger3 = db.TblKategoriler.Count();
            var deger4 = db.TblMarkalar.Count();
            var deger5 = db.TblSatışlar.Count();
            var deger6 = db.TblYorumlar.Count();
            var deger7 = db.TblDuyurular.Count();
            var deger8 = db.TblMesajlar.Count();
            var deger9 = db.trendler().FirstOrDefault();
            var deger10 = db.enazsatılanurun().FirstOrDefault();
            var deger11 = db.encoksatılankategorı().FirstOrDefault();
            var deger12 = db.enazsatılankategorı().FirstOrDefault();
            var deger13 = db.encoksatılanMarka().FirstOrDefault();
            var deger14 = db.enazsatılanMarka().FirstOrDefault();
            var deger15 = db.encokalımlımüşteri().FirstOrDefault();
            var deger16 = db.enazalımlımüşteri().FirstOrDefault();

            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;
            ViewBag.d5 = deger5;
            ViewBag.d6 = deger6;
            ViewBag.d7 = deger7;
            ViewBag.d8 = deger8;
            ViewBag.d9 = deger9;
            ViewBag.d10 = deger10;
            ViewBag.d11 = deger11;
            ViewBag.d12 = deger12;
            ViewBag.d13 = deger13;
            ViewBag.d14 = deger14;
            ViewBag.d15 = deger15;
            ViewBag.d16 = deger16;

            return View();
        }

    }
}