using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class MeniuController : Controller
    {
        private MeniuDbContext dbCtx = new MeniuDbContext();
        // GET: Meniu
        public ActionResult Index()
        {
            //MeniuModel m = dbCtx.Meniuri.SingleOrDefault(p => p.Id == 1);
            return View(dbCtx.Meniuri.ToList());
        }
    }
}