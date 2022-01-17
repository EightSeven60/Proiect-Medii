using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;
using System.Text;

namespace Restaurant.Controllers
{
    public class CreeareComandaController : Controller
    {
        // GET: CreeareComanda
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult CalculateTotal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CalculateTotalResult()
        {
            int amount = Convert.ToInt32(Request["txtAmount"].ToString());
            string numemeniu = Request["txtMeniu"].ToString();
            MeniuDbContext mdctx = new MeniuDbContext();
            var meniu = (from m in mdctx.Meniuri
                         where m.Nume.Contains(numemeniu)
                         select m).SingleOrDefault();
            StringBuilder sbChitanta = new StringBuilder();
            if (meniu!=null)
            {
               
                sbChitanta.Append("<b>Amount :</b> " + amount + "<br/>");
                sbChitanta.Append("<b>Menu :</b> " + numemeniu + "<br/>");
                sbChitanta.Append("<b>Total :</b> " + amount*meniu.Pret + "<br/>");
                return Content(sbChitanta.ToString());
            }
            else
            {
                sbChitanta.Append("nu ati dat date corecte");
                return Content(sbChitanta.ToString());
            }

            
        }
    }
}