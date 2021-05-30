using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;


namespace ButikSite.Controllers
{
    public class YorumlarController : Controller
    {
        ButikSiteEntities db = new ButikSiteEntities();
        // GET: Yorumlar
        public ActionResult Liste()
        {
            var liste = db.TblYorumlar.ToList();
            return View(liste);
        }
        public ActionResult Sil(int id)
        {
            var rmv = db.TblYorumlar.Find(id);
            db.TblYorumlar.Remove(rmv);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }
    }
}