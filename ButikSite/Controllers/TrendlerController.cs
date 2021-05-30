using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class TrendlerController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();
        // GET: Trendler
        public ActionResult Liste()
        {
            var bul = db.TblSatışlar.Include(x => x.TblÜrünler).GroupBy(x => x.TblÜrünler.Id).ToList();
         
            

          

           
           
            return View(bul);
        }
    }
}