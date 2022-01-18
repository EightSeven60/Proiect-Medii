using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class LogareController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logare()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogareResult()
        {
            string username = Request["txtUtilizator"].ToString();
            string password = Request["txtPassword"].ToString();
            if (password == "1234")
            {
                string mesaj = "Succes";
                UserController.iduser = 1;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string mesaj = "Eroare";
                return Content(mesaj);
            }
        }
    }
}