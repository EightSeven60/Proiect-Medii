﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        public static int iduser =0;
        private UserDbContext dbCtxt = new UserDbContext();
        // GET: User
        public ActionResult Index()
        {
            return View(dbCtxt.Users.ToList());
        }
    }
}