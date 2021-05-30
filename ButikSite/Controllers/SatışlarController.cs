using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class SatışlarController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();
        // GET: Satışlar
        public ActionResult Liste()
        {
            var liste = db.TblSatışlar.ToList();
            return View(liste);
        }
    }
}