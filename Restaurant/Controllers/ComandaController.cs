using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class ComandaController : Controller
    {
        public static int idcomanda =1;
        private MeniuDbContext dbCtx = new MeniuDbContext();
        private ComandaDbContext cmdctx = new ComandaDbContext();
        // GET: Comanda
        public ActionResult Index()
        {
            return View(dbCtx.Meniuri.ToList());
        }
        /*public ActionResult Comanda(ComandaModel m)
        {
            ComandaModel comanda = cmdctx.Comenzi.SingleOrDefault(cm => cm.Id == idcomanda);
            if (ModelState.IsValid)
            {
                comanda.MeniuId = m.Id;
                comanda.Nrmeniuri++;
            }
            cmdctx.SaveChanges();
            return View(cmdctx.Comenzi.ToList());
        }*/
        /*public ActionResult Comanda(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            MeniuModel meniu = dbCtx.Meniuri.Find(id);
            if (null == meniu)
            {
                return HttpNotFound();
            }
            return View(meniu);
        }*/
        public ActionResult Comanda(int? id)
        {
            if (!id.HasValue)
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            MeniuModel meniu = dbCtx.Meniuri.Find(id);
            if (null == meniu)
            {
                return HttpNotFound();
            }
            return View(meniu);
        }
        [HttpPost, ActionName("Comanda")]
        [ValidateAntiForgeryToken]
        public ActionResult ComandaConfirmed(int id)
        {
            if (ModelState.IsValid)
            {

                MeniuModel meniu = dbCtx.Meniuri.Find(id);
                ComandaModel comanda = cmdctx.Comenzi.SingleOrDefault(cm => cm.Id == idcomanda);
                if (ModelState.IsValid)
                {
                    comanda.MeniuId = meniu.Id;
                    comanda.Nrmeniuri++;
                }
                cmdctx.SaveChanges();

            }
            //Task.Run(() => TraceWriter.WriteLineToTraceAsync("Model state was not valid in "Delete" post method in "Meniu Controller"."));
            return RedirectToAction("Index");

        }
    }

}
