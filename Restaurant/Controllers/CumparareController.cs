using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Controllers;
using Restaurant.Models;
using System.Text;

namespace Restaurant.Controllers
{
    public class CumparareController : Controller
    {
        // GET: Cumparare
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Total()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TotalResult()
        {
            double suma = CreeareComandaController.sumatotal;
            double plata = Convert.ToDouble(Request["txtSuma"].ToString());
            StringBuilder sb = CreeareComandaController.sb;
            if(plata-suma >= 0)
            {
                sb.Append("Suma :   " + plata +"<br/>");
                sb.Append("Rest:    " + (plata - suma) + "<br/>");
            }
            else
            {
                sb.Append("Fonduri insuficiente!");
            }
            return Content(sb.ToString());
        }
    }
}
