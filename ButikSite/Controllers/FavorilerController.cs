using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class FavorilerController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();
        // GET: Favoriler
        public ActionResult Liste()
        {
            var liste = db.TblFavoriler.ToList();
            return View(liste);
        }
    }
}