using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButikSite.Models;

namespace ButikSite.Controllers
{
    public class VitrinDuyuruController : Controller
    {
        // GET: VitrinDuyuru
        ButikSiteEntities db = new ButikSiteEntities();
        public ActionResult Liste()
        {
            Class1 bgl = new Class1();
            bgl.dyr = db.TblDuyurular.ToList();
            

            return View(bgl);
        }
    }
}