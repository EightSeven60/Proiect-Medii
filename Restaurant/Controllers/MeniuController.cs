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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MeniuModel msg)
        {
            if (ModelState.IsValid)
            {
                dbCtx.Meniuri.Add(msg);
                dbCtx.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(msg);
        }
        public ActionResult Edit(int? id)
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
        }
        [HttpPost]
        public ActionResult Edit(MeniuModel meniu)
        {
            if (ModelState.IsValid)
            {
                foreach (string idstring in meniu.Idproduse.Split(' '))
                {
                    try
                    {
                        int idprodus = int.Parse(idstring);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Eroare");
                    }
                }
                dbCtx.Entry(meniu).State = System.Data.Entity.EntityState.Modified;
                dbCtx.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(meniu);
        }
        public ActionResult Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {

                MeniuModel personalDetail = dbCtx.Meniuri.Find(id);
                dbCtx.Meniuri.Remove(personalDetail);
                dbCtx.SaveChanges();

            }
            //Task.Run(() => TraceWriter.WriteLineToTraceAsync("Model state was not valid in "Delete" post method in "Meniu Controller"."));
            return RedirectToAction("Index");

        }
    }
}