using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class ProdusController : Controller
    {
        private ProdusDbContext dbCtx = new ProdusDbContext();
        // GET: Produs
        public ActionResult Index()
        {
            return View(dbCtx.Produse.ToList());
        }
    }
}