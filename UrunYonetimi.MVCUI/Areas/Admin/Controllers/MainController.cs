﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrunYonetimi.MVCUI.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        // GET: Admin/Main
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}