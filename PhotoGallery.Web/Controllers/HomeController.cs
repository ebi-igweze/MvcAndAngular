﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoGallery.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //var galleries = VGalleryManager.GetGallery(4);
            //return Json(galleries, JsonRequestBehavior.AllowGet);
            return View();
        }

        public JsonResult Galleries()
        {
            var result = VGalleryManager.AllGalleries();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateGallery()
        {
            return View();
        }
    }
}